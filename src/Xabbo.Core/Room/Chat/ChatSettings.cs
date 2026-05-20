using Xabbo.Messages;

namespace Xabbo.Core;

/// <inheritdoc cref="IChatSettings"/>.
public class ChatSettings : IChatSettings, IParserComposer<ChatSettings>
{
    public ChatFlow Flow { get; set; }
    public ChatBubbleWidth BubbleWidth { get; set; }
    public ChatScrollSpeed ScrollSpeed { get; set; }
    public int TalkHearingDistance { get; set; }
    public ChatFloodProtection FloodProtection { get; set; }

    /// <summary>
    /// The chat text size selected for the room, added by Habbo in the May 2026 client update.
    /// May be <c>null</c> when the hotel runs the older protocol that did not include this field.
    /// </summary>
    public int? TextSize { get; set; }

    /// <summary>
    /// A trailing boolean flag introduced alongside <see cref="TextSize"/> in the May 2026 update.
    /// Its meaning is not yet documented by Habbo; the value tracks an entry-time signal so it
    /// usually mirrors <c>IRoomData.IsEntering</c>.
    /// </summary>
    public bool? Unknown1 { get; set; }

    public ChatSettings()
    {
        Flow = ChatFlow.LineByLine;
        BubbleWidth = ChatBubbleWidth.Normal;
        ScrollSpeed = ChatScrollSpeed.Normal;
        TalkHearingDistance = 14;
        FloodProtection = ChatFloodProtection.Standard;
    }

    internal ChatSettings(in PacketReader p)
    {
        Flow = ChatFlow.LineByLine;
        BubbleWidth = ChatBubbleWidth.Normal;
        ScrollSpeed = ChatScrollSpeed.Normal;
        TalkHearingDistance = 14;
        FloodProtection = ChatFloodProtection.Standard;

        // May 2026 Habbo update: the old layout of five ints (Flow, BubbleWidth, ScrollSpeed,
        // TalkHearingDistance, FloodProtection) was replaced with a single int TextSize followed
        // by a one-byte flag. Detect by available bytes so the parser works with both layouts.
        if (p.Available >= 20)
        {
            Flow = (ChatFlow)p.ReadInt();
            BubbleWidth = (ChatBubbleWidth)p.ReadInt();
            ScrollSpeed = (ChatScrollSpeed)p.ReadInt();
            TalkHearingDistance = p.ReadInt();
            FloodProtection = (ChatFloodProtection)p.ReadInt();
        }
        else if (p.Available >= 5)
        {
            TextSize = p.ReadInt();
            Unknown1 = p.ReadBool();
        }
        else if (p.Available >= 4)
        {
            TextSize = p.ReadInt();
        }
        else if (p.Available >= 1)
        {
            Unknown1 = p.ReadBool();
        }
    }

    void IComposer.Compose(in PacketWriter p)
    {
        // Compose in the new layout when TextSize is set; otherwise fall back to the old five-int
        // layout so extensions composing legacy packets keep working.
        if (TextSize.HasValue || Unknown1.HasValue)
        {
            p.WriteInt(TextSize ?? 1);
            p.WriteBool(Unknown1 ?? false);
        }
        else
        {
            p.WriteInt((int)Flow);
            p.WriteInt((int)BubbleWidth);
            p.WriteInt((int)ScrollSpeed);
            p.WriteInt(TalkHearingDistance);
            p.WriteInt((int)FloodProtection);
        }
    }

    static ChatSettings IParser<ChatSettings>.Parse(in PacketReader p) => new(in p);
}
