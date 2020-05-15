namespace Automation_CodeReadingModel
{
    public enum LoginState
    {
        登录,
        未登录
    }
    public class LoginInfo
    {
        public static LoginState state = LoginState.未登录;
    }
}
