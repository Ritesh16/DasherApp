using DasherApp.Services.Interfaces;

namespace DasherApp
{
    public class AppState
    {
        public double TotalAmount { get; set; }
        public double TotalMileage { get; set; }

        public event Action OnChange;
        public void LoadHeaders(double totalAmount, double totalMileage)
        {
            TotalAmount = totalAmount;
            TotalMileage = totalMileage;

            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
