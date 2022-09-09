namespace RealSolutionFolders.Dialogs;

using Input;

public partial class SolutionFolderDialog : DialogWindow, INotifyPropertyChanged
{
    #region Fields

    private string solutionName = "Solution";
    private string folderPath = string.Empty;
    private string folderName = "New Folder";

    #endregion

    #region Properties

    public string SolutionName
    {
        get => solutionName;
        set
        {
            solutionName = value;
            OnPropertyChanged();
        }
    }

    public string FolderPath
    {
        get => folderPath;
        set
        {
            folderPath = value;
            OnPropertyChanged();
        }
    }

    public string FolderName
    {
        get => folderName;
        set
        {
            folderName = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region Commands

    private ICommand dialogAccept;
    private ICommand dialogCancel;

    public RelayCommand DialogAcceptCommand
    {
        get
        {
            dialogAccept ??= new RelayCommand(
                x => true,
                x => DialogResult = true);
            return (RelayCommand)dialogAccept;
            
        }
    }

    public RelayCommand DialogCancelCommand
    {
        get
        {
            dialogCancel ??= new RelayCommand(
                x => true,
                x => DialogResult = false);
            return (RelayCommand)dialogCancel;

        }
    }

    #endregion

    #region Constructors

    public SolutionFolderDialog()
    {
        InitializeComponent();
        Input_FolderName.Loaded += (_, _) => Input_FolderName.SelectAll();
    }

    #endregion

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Raises this object's PropertyChanged event.
    /// </summary>
    /// <param name="propertyName">The property that has a new value.</param>
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler is not null)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            handler(this, e);
        }
    }

    #endregion
}
