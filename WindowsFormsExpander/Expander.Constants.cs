using System.Windows.Forms;

#nullable enable

namespace WindowsFormsExpander
{
    partial class Expander
    {
        const int defaultHeaderHeight = 24;
        const int defaultExpandedHeight = 100;
        const int headerPadding = 4;
        const int focusPadding = 2;
        const int imageSize = 16;

        static readonly ControlStyles enabledStyles =
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.ContainerControl |
            ControlStyles.DoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.Selectable |
            ControlStyles.StandardClick |
            ControlStyles.StandardDoubleClick |
            ControlStyles.SupportsTransparentBackColor |
            ControlStyles.UserPaint;
        static readonly ControlStyles disabledStyles =
            ControlStyles.CacheText |
            ControlStyles.EnableNotifyMessage |
            ControlStyles.FixedHeight |
            ControlStyles.FixedWidth |
            ControlStyles.Opaque |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.UseTextForAccessibility |
            ControlStyles.UserMouse;
    }
}