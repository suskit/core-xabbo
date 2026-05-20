namespace Xabbo.Core;

/// <summary>
/// Defines chat related settings for a room.
/// </summary>
public interface IChatSettings
{
    /// <summary>
    /// Specifies the chat flow behavior.
    /// </summary>
    ChatFlow Flow { get; }

    /// <summary>
    /// Specifies the chat bubble width;
    /// </summary>
    ChatBubbleWidth BubbleWidth { get; }

    /// <summary>
    /// Specifies the chat scroll speed.
    /// </summary>
    ChatScrollSpeed ScrollSpeed { get; }

    /// <summary>
    /// Specifies the distance at which users can hear each other talk.
    /// </summary>
    int TalkHearingDistance { get; }

    /// <summary>
    /// Specifies the chat flood protection level.
    /// </summary>
    ChatFloodProtection FloodProtection { get; }

    /// <summary>
    /// Specifies the chat text size selected for the room.
    /// <para/>
    /// This is <c>null</c> when the hotel runs a protocol that does not include the field.
    /// </summary>
    int? TextSize { get; }

    /// <summary>
    /// A trailing boolean flag introduced alongside <see cref="TextSize"/> in the May 2026 update.
    /// </summary>
    bool? Unknown1 { get; }
}
