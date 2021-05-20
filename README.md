# Frontend için gerekli değişiklikler

* Findeks kontrolü

```c#
 private IResult CheckFindeks(int carFindeks,int customerFindeks)
        {
            var customerFin = _customerService.Findeks(customerFindeks);
            var carFin = _carService.Findeks(carFindeks);
            if (carFin.Data>customerFin.Data)
            {
                return new ErrorResult(Messages.FindeksFail);
            }
            return new SuccessResult(Messages.FindeksSuccess);
            
        }
 public IDataResult<int> Findeks(int cusId)
        {
            var result = _customerDal.Get(c => c.Id == cusId);
            return new SuccessDataResult<int>(result.Findeks);
        }
  public IDataResult<int> Findeks(int carId)
        {
            var result = _carDal.Get(c => c.Id == carId);
            return new SuccessDataResult<int>(result.MinFindeks);
        }
        
    public CustomerValidator()
        {
            RuleFor(cu => cu.CompanyName).NotEmpty();
            RuleFor(cu => cu.Findeks).InclusiveBetween(0, 1900);
        }     
```



# User Update
* User operasyonları Auth service e uygun hale getirildi
```C#
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
        
 ```




# Fake Kart 
* Fake kart için Service oluşturuldu 

<img src="https://github.com/ElSenpai/Rental-oldVersion/blob/master/src/assets/img/h4.png" width="800" alt="main">

# Register Sırasında değişiklikler
* Register olunca kullanıcı user claimi kazanıp Customer haline geliyor
[AuthManager](https://github.com/ElSenpai/CarRentalProject/blob/master/Business/Concrete/AuthManager.cs)
```c#
 public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            _userOperationService.Add(new UserOperationClaim { OperationClaimId = 2, UserId = user.Id });
            _customerService.Add(new Customer { UserId = user.Id, Findeks = 500, CompanyName = user.LastName + " Company" });

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }
```

# Filtreleme için Eklenen Operasyonlar

![some](https://github.com/ElSenpai/Rental-oldVersion/blob/master/src/assets/img/h5.png)

# Nuget Packages and Their Versions

* Autofac - Version = v6.1.0
* Autofac.Extensions.DependencyInjection - Version = v7.1.0
* Autofac.Extras.DynamicProxy - Version = v6.0.0
* FluentValidation - Version = v9.5.1
* Microsoft.AspNetCore.Authentication.JwtBearer - Version = v3.1.12
* Microsoft.AspNetCore.Http - Version = v2.2.2
* Microsoft.AspNetCore.Http.Abstractions - Version = v2.2.0
* Microsoft.AspNetCore.Http.Features - Version = v5.0.3
* Microsoft.EntityFrameworkCore.SqlServer - Version = v3.1.12
* Microsoft.IdentityModel.Tokens - Version = v6.8.0
* Newtonsoft.Json - Version = v13.0.1
* System.IdentityModel.Tokens.Jwt - Version = v6.8.0

[El Senpai](https://github.com/ElSenpai/)

