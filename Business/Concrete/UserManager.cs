﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class UserManager :IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UsersListed);
        }

        public IDataResult<User> GetByUserId(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id==id), Messages.UserListed);
        }

        public IResult Update(User user,string password)
        {
            
            var result = _userDal.Get(c=>c.Id==user.Id);

            user.PasswordHash = result.PasswordHash;
            user.PasswordSalt = result.PasswordSalt;
            user.Status = result.Status;
            if (user.FirstName == null)
            { user.FirstName = result.FirstName; }
           if(user.LastName == null )
            { user.LastName = result.LastName; }
            if (user.Email == null )
              {user.Email = result.Email; }
            if(password != "null")
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
           
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var getClaims = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(getClaims);
        }
      

        public IDataResult<User> GetByMail(string email)
        {
            var getByMail = _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(getByMail);
        }
    }
}
