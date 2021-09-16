namespace ToDoApp.Core.Configuration
{
    public class Constants
    {
        public class ErrorMessages
        {
            public const string UserWithIdDoesNotExist = "User with provided UserId does not exist.";
            public const string ListWithIdDoesNotExist = "List with provided ListId does not exist.";
            public const string UserDoesNotOwnSpecificList = "User does not own a list with this ListId.";
            public const string ToDoItemWithItemIdDoesNotExist = "ToDo item with provided ItemId does not exist.";
            public const string NoPasswordChangeForAdminRole = "System does not allow password change for admins.";
            public const string PasswordRecoveryNotInitiated = "Password recovery was not requested for this user, please request it first.";
            public const string UsernameOrPasswordIsWrong = "Username or password is incorrect";
            public const string Unauthorized = "Unauthorized.";
            public const string Forbidden = "Forbidden.";
        }

        public class Exception
        {
            public const string ToDoListWasNotFound = "ToDo List id is not found.";
            public const string DBInitalizationFailed = "An error occurred creating the DB.";
        }

        public class Jwt
        {
            public const string User = "User";
            public const string Authorization = "Authorization";
            public const string UserId = "id";
        }

        public class FieldValidaton
        {
            public const int MinPasswordLength = 12;
        }
    }
}
