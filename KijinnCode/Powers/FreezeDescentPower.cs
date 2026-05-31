using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using STS2RitsuLib.Interop.AutoRegistration;
using STS2RitsuLib.Scaffolding.Content;

namespace Kijinn.KijinnCode.Powers;

[RegisterPower]
public class FreezeDescentPower : ModPowerTemplate
{
    // 类型，Buff或Debuff
    public override PowerType Type => PowerType.Buff;
    // 叠加类型，Counter表示可叠加，Single表示不可叠加
    public override PowerStackType StackType => PowerStackType.Single;

    // 自定义图标路径。1:1即可。原版游戏大图256x256，小图64x64。
    public override PowerAssetProfile AssetProfile => new(
        IconPath: "res://Kijinn/images/powers/Test.png",
        BigIconPath: "res://Kijinn/images/powers/Test_b.png"
    );

    //不是很懂，但是总之会让赋予能力本身的那张牌不计入计算
    private class Data
    {
        public readonly Dictionary<CardModel, int> amountsForPlayedCards = new Dictionary<CardModel, int>();
    } 
    
    protected override object InitInternalData()
    {
        return new Data();
    }
    
    public override Task BeforeCardPlayed(CardPlay cardPlay)
    {
        if (cardPlay.Card.Owner.Creature != base.Owner)
        {
            return Task.CompletedTask;
        }
        GetInternalData<Data>().amountsForPlayedCards.Add(cardPlay.Card, base.Amount);
        return Task.CompletedTask;
    }
    //一直到这块

    public override async Task AfterCardPlayed(PlayerChoiceContext context, CardPlay cardPlay)
    {
        if (cardPlay.Card.Type == CardType.Attack)
        {
            await PowerCmd.Apply<WeakPower>(cardPlay.Target, 1, Owner, null);
        }

        if (cardPlay.Card.Type == CardType.Skill && GetInternalData<Data>().amountsForPlayedCards.Remove(cardPlay.Card, out var value) && value > 0)
        {
            await PowerCmd.Apply<VigorPower>(Owner, 2, Owner, null);
        }
    }
}