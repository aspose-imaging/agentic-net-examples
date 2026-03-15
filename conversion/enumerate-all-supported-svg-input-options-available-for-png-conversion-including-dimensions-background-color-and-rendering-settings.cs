using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";

        using (Image image = Image.Load(inputPath))
        {
            int width = image.Width;
            int height = image.Height;
            Console.WriteLine($"SVG Dimensions: {width}x{height}");

            SvgRasterizationOptions svgOptions = new SvgRasterizationOptions();
            svgOptions.PageWidth = width;
            svgOptions.PageHeight = height;

            Console.WriteLine($"Background Color: {svgOptions.BackgroundColor}");
            Console.WriteLine($"Page Size: {svgOptions.PageSize.Width}x{svgOptions.PageSize.Height}");
            Console.WriteLine($"ScaleX: {svgOptions.ScaleX}, ScaleY: {svgOptions.ScaleY}");
            Console.WriteLine($"Smoothing Mode: {svgOptions.SmoothingMode}");
            Console.WriteLine($"Text Rendering Hint: {svgOptions.TextRenderingHint}");
            Console.WriteLine($"BorderX: {svgOptions.BorderX}, BorderY: {svgOptions.BorderY}");
            Console.WriteLine($"Center Drawing: {svgOptions.CenterDrawing}");
            Console.WriteLine($"Draw Color: {svgOptions.DrawColor}");
            Console.WriteLine($"Page Width: {svgOptions.PageWidth}, Page Height: {svgOptions.PageHeight}");
            Console.WriteLine($"Positioning: {svgOptions.Positioning}");
            Console.WriteLine($"Replace Text Mapping set: {svgOptions.ReplaceTextMapping != null}");
        }
    }
}