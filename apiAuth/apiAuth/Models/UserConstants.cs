namespace apiAuth.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new()
        {
           new UserModel(){UserName="marcio", Password="marcio_75", Role="Admin"},
           new UserModel(){UserName="chat", Password="chatbot857", Role="chatUser"}
        };
    }
}
