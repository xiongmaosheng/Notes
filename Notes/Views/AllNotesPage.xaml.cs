namespace Notes.Views;

public partial class AllNotesPage : ContentPage
{
    public AllNotesPage()
    {
        InitializeComponent();
        BindingContext = new Models.AllNotes();
    }

    protected override void OnAppearing()
    {
        ((Models.AllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            //��ȡ�ʼ�ģ��
            var note = (Models.Note)e.CurrentSelection[0];
            //Ӧ�õ�������NotePage?ItemId=path\on\device\XYZ.notes.txt��
            var address = $"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}";
            await Shell.Current.GoToAsync(address);
            //ȡ��ѡ��UI
            notesCollection.SelectedItem = null;
        }
    }
}