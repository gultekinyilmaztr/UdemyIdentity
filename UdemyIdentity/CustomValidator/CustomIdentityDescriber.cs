using Microsoft.AspNetCore.Identity;

namespace UdemyIdentity.CustomValidator
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "InvalidUserName",
                Description = $"Bu {userName} geçersizdir."
            };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "DuplicateUserName",
                Description = $"Bu Kullanıcı Adı({userName}) zaten kullanılmaktadır."
            };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = $"Bu {email} kullanılmaktadır."
            };
        }
        public override IdentityError PasswordTooShort(int lenght)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Şifreniz en az {lenght} karakterli olmalıdır."
            };
        }

    }
}
