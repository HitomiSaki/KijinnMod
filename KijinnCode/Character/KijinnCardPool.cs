using Godot;
using STS2RitsuLib.Scaffolding.Content;
using STS2RitsuLib.Utils;

namespace Kijinn.KijinnCode.Character;

public class KijinnCardPool : TypeListCardPoolModel
{
    // 卡池的ID。必须唯一防撞车。
    public override string Title => "Kijinn";
    public override string EnergyColorName => "Kijinn";

    // 描述中使用的能量图标。大小为24x24。
    public override string? TextEnergyIconPath => "res://Kijinn/images/UI/energy_min.png";
    // tooltip和卡牌左上角的能量图标。大小为74x74。
    public override string? BigEnergyIconPath => "res://Kijinn/images/UI/energy.png";


    // 卡池的主题色。
    public override Color DeckEntryCardColor => new(0.43f, 0.8f, 1f);
    // 能量表盘文字轮廓颜色
    public override Color EnergyOutlineColor => new(0.34f, 0.05f, 0f);
    // 如果你想用原版卡框换色，加这两行
    // private static readonly Material? _poolFrameMaterial = MaterialUtils.CreateRgbShaderMaterial(0.5f, 0.5f, 1f);
    // 如果你是自定义卡框，上面一行换成这个
    private static readonly Material? _poolFrameMaterial = MaterialUtils.CreateUnmodulatedHsvShaderMaterial();
    public override Material? PoolFrameMaterial => _poolFrameMaterial;
    // 卡池是否是无色。例如事件、状态等卡池就是无色的。
    public override bool IsColorless => false;
}