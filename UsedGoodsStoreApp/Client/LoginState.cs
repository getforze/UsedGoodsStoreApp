using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client
{
    public class LoginState
    {
        public UserDTO User { get; set; } = new UserDTO();
        public event Action OnChange;
        public void NotifyStateChanged() => OnChange?.Invoke();
        public void AssignUser(UserDTO user)
        {
            User = user;
            NotifyStateChanged();
        }
        public void Logout()
        {
            AssignUser(new UserDTO());
        }

    }
}
