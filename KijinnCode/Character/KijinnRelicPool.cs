using STS2RitsuLib.Scaffolding.Content;

namespace Kijinn.KijinnCode.Character;

public class KijinnRelicPool : TypeListRelicPoolModel
{
    // 描述中使用的能量图标。大小为24x24。
    public override string? TextEnergyIconPath => "res://Kijinn/images/energy_test.png";
    // tooltip和卡牌左上角的能量图标。大小为74x74。
    public override string? BigEnergyIconPath => "res://Kijinn/images/energy_test_big.png";

    public override string EnergyColorName => "Kijinn";
}