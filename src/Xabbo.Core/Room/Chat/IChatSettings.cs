namespace Xabbo.Core;

/// <summary>
/// Defines chat related settings for a room.
/// </summary>
public interface IChatSettings
{
    /// <summary>
    /// The chat text size.
    /// </summary>
    int TextSize { get; }

    // unknown
    bool Unknown1 { get; }

    // legacy fields kept for UI/extension compatibility on the core-xabbo branch;
    // habbo dropped these from the wire so the values are defaults only.
    ChatFlow Flow { get; }
    ChatBubbleWidth BubbleWidth { get; }
    ChatScrollSpeed ScrollSpeed { get; }
    int TalkHearingDistance { get; }
    ChatFloodProtection FloodProtection { get; }
}
