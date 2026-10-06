using AutoMapper;
using CashFlow.Application.UseCases.Validators;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.Exception.ExceptionsBase;
using CashFlow.Exception.ExceptionsBase.Messages;
using FluentValidation.Results;

namespace CashFlow.Application.UseCases.Expenses.Users;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IUnitOfWork _unityOfWork;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IAccessTokenGenerator _tokenGenerator;
    public RegisterUserUseCase(
        IMapper mapper, 
        IPasswordEncripter passwordEncripter,
        IUserReadOnlyRepository userReadOnlyRepository,
        IUnitOfWork unityOfWork,
        IUserWriteOnlyRepository userWriteOnlyRepository,
        IAccessTokenGenerator tokenGenerator)

    {
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;
        _userReadOnlyRepository = userReadOnlyRepository;
        _unityOfWork = unityOfWork;
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        await Validate(request);        

        User user = _mapper.Map<Domain.Entities.User>(request);
        user.Password = _passwordEncripter.Encrypt(request.Password);
        user.UserIdentifer = Guid.NewGuid();
        
        await _userWriteOnlyRepository.Add(user);
        await _unityOfWork.Commit();

        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Token = _tokenGenerator.Generate(user)
        };
    }

    private async Task Validate(RequestRegisterUserJson request)
    {
      var result = new RegisterUserValidator().Validate(request);
      var emailExist = await  _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
      
        if(emailExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
        }
    
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }

    }
}
