namespace RealSolutionFolders;

using Dialogs;

[Command(PackageIds.NewFolderCommand)]
internal sealed class NewFolderCommand : BaseCommand<NewFolderCommand>
{
    protected override void Execute(object sender, EventArgs e)
    {
        try
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var dte = Package.GetService<SDTE, DTE2>();
            var solution = (Solution2)dte.Solution;
            var projects = solution.Projects;
            var solutionName = Path.GetFileNameWithoutExtension(solution.FullName);
            var solutionPath = Path.GetDirectoryName(solution.FullName);

            var modal = new SolutionFolderDialog()
            {
                SolutionName = solutionName,
                FolderPath = solutionPath,
            };

            var modalResult = modal.ShowModal();

            if (modalResult == true)
            {
                var folderName = modal.FolderName;
                var folderDir = Directory.CreateDirectory(Path.Combine(solutionPath, folderName));
                solution.AddSolutionFolder(folderName);
                dte.ExecuteCommand("File.SaveAll");
            }
        }
        catch (Exception ex)
        {
            VS.MessageBox.ShowError($"An error was encountered while creating the solution folder:\n{ex.Message}");
        }

        base.Execute(sender, e);
    }
}
