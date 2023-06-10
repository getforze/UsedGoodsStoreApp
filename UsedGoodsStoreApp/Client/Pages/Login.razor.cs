namespace UsedGoodsStoreApp.Client.Pages
{
    public partial class Login
    {
        protected override void OnInitialized()
        {
            LoginState.OnChange += StateHasChanged;
        }
        protected override void OnAfterRender(bool firstRender)
        {
            if(LoginState.User.UserId != 0)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
