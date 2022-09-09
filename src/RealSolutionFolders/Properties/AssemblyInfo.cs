using RealSolutionFolders;

[assembly:
    // Settings
    ComVisible(false),
    // Package Info
    AssemblyTitle(Vsix.Name),
    AssemblyDescription(Vsix.Description),
    AssemblyConfiguration(""),
    AssemblyCompany(Vsix.Author),
    AssemblyProduct(Vsix.Name),
    AssemblyCopyright(Vsix.Author),
    AssemblyTrademark(""),
    AssemblyCulture(""),
    // Version Info
    AssemblyVersion(Vsix.Version),
    AssemblyFileVersion(Vsix.Version)
]

// init feature fix for net framework

namespace System.Runtime.CompilerServices; 

public class IsExternalInit { }
