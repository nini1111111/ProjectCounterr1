namespace Counter22.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class CountersPage : ContentPage
{
    public string ItemId
    {
        set { LoadCounter(value); }
    }

    public CountersPage()
    {
        InitializeComponent();
    }
    private void LoadCounter(string filename)
    {
        Models.Counter counterModel = new()
        {
            Filename = filename,
            Text = "",
            Count = 0
        };

        if (File.Exists(filename))
        {
            counterModel.Date = File.GetCreationTime(filename);
            counterModel.Text = File.ReadAllText(filename);
        }

        string countFile = filename + ".count";

        if (File.Exists(countFile))
        {
            int.TryParse(File.ReadAllText(countFile), out int savedCount);
            counterModel.Count = savedCount;
        }

        BindingContext = counterModel;
        CounterLbl.Text = $"Clicked {counterModel.Count} times";
    }

    private void SaveCounter()
    {
        if (BindingContext is Models.Counter counter)
        {
            string countFile = counter.Filename + ".count";

            File.WriteAllText(
                countFile,
                counter.Count.ToString()
            );
        }
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Counter note)
        {
            File.WriteAllText(note.Filename, TextEditor.Text ?? "");
            SaveCounter();
        }

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Counter note)
        {
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);

            string countFile = note.Filename + ".count";

            if (File.Exists(countFile))
                File.Delete(countFile);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void OnAdditionClicked(object? sender, EventArgs e)
    {
        if (BindingContext is Models.Counter counter)
        {
            counter.Count++;
            CounterLbl.Text = $"Clicked {counter.Count} times";
            SaveCounter();

            SemanticScreenReader.Announce(CounterLbl.Text);
        }
    }
    private void OnSubstractionClicked(object? sender, EventArgs e)
    {
        if (BindingContext is Models.Counter counter)
        {
            counter.Count--;
            CounterLbl.Text = $"Clicked {counter.Count} times";
            SaveCounter();
            SemanticScreenReader.Announce(CounterLbl.Text);
        }
    }
}