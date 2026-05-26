using System.Reflection;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;
using STS2RitsuLib;
using STS2RitsuLib.Interop;

namespace Kjinn;

// 必须要加的属性，用于注册Mod。字符串和初始化函数命名一致。
[ModInitializer(nameof(Init))]
public class MainFile
{
    // 你的modid
    public const string ModId = "Kijinn";
    public static readonly Logger Logger = RitsuLibFramework.CreateLogger(ModId);
    // 初始化函数
    public static void Init()
    {
        // // 打patch（即修改游戏代码的功能）用
        // // 传入参数随意，只要不和其他人撞车即可
        // var harmony = new Harmony("sts2.Kijinn");
        // harmony.PatchAll();
        // // 使得tscn可以加载自定义脚本
        // ScriptManagerBridge.LookupScriptsInAssembly(typeof(Mainfile).Assembly);
        // Log.Info("Mod initialized!");
        
        // harmony可用，但是最好用ritsu的封装patch（TODO）
        // var harmony = new Harmony("com.example.testmod");
        // harmony.PatchAll();
        var assembly = Assembly.GetExecutingAssembly();
        RitsuLibFramework.EnsureGodotScriptsRegistered(assembly, Logger);
        // 自动注册内容
        ModTypeDiscoveryHub.RegisterModAssembly(ModId, assembly);
    }
}