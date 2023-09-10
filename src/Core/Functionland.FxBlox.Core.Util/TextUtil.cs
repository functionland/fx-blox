using Html2Markdown;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Functionland.FxBlox.Core.Util;

public static class TextUtil
{
    public static string HtmlToMarkDown(this string html)
    {
        var converter = new Converter();
        return converter.Convert(html);
    }
}
