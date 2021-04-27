<h1>** Frontend için gerekli değişiklikler</h1>

<h3> Findeks kontrolü</h3>

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


<img src="https://github.com/ElSenpai/Rental-oldVersion/blob/master/src/assets/img/h6.png" width="800" alt="main">

<h1> Fake Kart </h3>
<h3> - Fake kart için Service oluşturuldu </h1>

<img src="https://github.com/ElSenpai/Rental-oldVersion/blob/master/src/assets/img/h4.png" width="800" alt="main">

<h1> Register Sırasında değişiklikler </h3>
<h3> - Register olunca kullanıcı user claimi kazanıp Customer haline geliyor  </h1>

<img src="https://github.com/ElSenpai/Rental-oldVersion/blob/master/src/assets/img/h3.png" width="800" alt="main">

<h1> Filtreleme için Eklenen Operasyonlar </h3>

![some](https://github.com/ElSenpai/Rental-oldVersion/blob/master/src/assets/img/h5.png)


[El Senpai](https://github.com/ElSenpai/)

