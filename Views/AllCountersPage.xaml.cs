namespace Counter22.Views;

public partial class AllCountersPage : ContentPage
{
    public AllCountersPage()
    {
        InitializeComponent();
        BindingContext = new Models.AllCounter();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ((Models.AllCounter)BindingContext).LoadCounters();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        string filename = Path.Combine(
            FileSystem.AppDataDirectory,
            $"{Path.GetRandomFileName()}.note"
        );

        await Shell.Current.GoToAsync(
            $"{nameof(CountersPage)}?ItemId={Uri.EscapeDataString(filename)}"
        );
    }

    private async void NotesCollection_SelectionChange(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var note = (Models.Counter)e.CurrentSelection[0];
            await Shell.Current.GoToAsync(
                $"{nameof(CountersPage)}?ItemId={Uri.EscapeDataString(note.Filename)}");

            NotesCollection.SelectedItem = null;
        }
    }
}