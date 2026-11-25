using Font = Microsoft.Maui.Font;

namespace Counter22;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(
            nameof(Views.CountersPage),
            typeof(Views.CountersPage)
        );
    }
}