using UnityEditor;
using UnityEditor.Compilation;

namespace CyanLib.Hotkeys
{
    public static class CompileProject {
        [MenuItem("File/Compile _F5")]
        static void Compile() {
            CompilationPipeline.RequestScriptCompilation(RequestScriptCompilationOptions.CleanBuildCache);
        }
    }
}