using Sharpmake;
using System.IO;

[Export]
public class RexPIX : PlatformProject
{
  public RexPIX() : base()
  {
    // The name of the project in Visual Studio. The default is the name of
    // the class, but you usually want to override that.
    Name = "RexPIX";
    GenerateTargets();

    string ThisFileFolder = Path.GetDirectoryName(Utils.CurrentFile());
    SourceRootPath = ThisFileFolder;
  }

  protected override void SetupIncludePaths(RexConfiguration conf, RexTarget target)
  {
    base.SetupIncludePaths(conf, target);

    conf.IncludePaths.Add(Path.Combine(SourceRootPath, "Include"));
  }

  protected override void SetupLibDependencies(RexConfiguration conf, RexTarget target)
  {
    base.SetupLibDependencies(conf, target);

    conf.TargetPath = Path.Combine(SourceRootPath, "bin", "x64");

    conf.TargetFileName = "WinPixEventRuntime";
    conf.Output = Configuration.OutputType.Lib;
  }
}