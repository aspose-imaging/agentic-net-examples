using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        using (SvgOptions svgOptions = new SvgOptions())
        {
            Console.WriteLine("SvgOptions properties (input options for SVG):");
            Console.WriteLine($"BufferSizeHint: {svgOptions.BufferSizeHint}");
            Console.WriteLine($"Compress (output compression): {svgOptions.Compress}");
            Console.WriteLine($"FullFrame: {svgOptions.FullFrame}");
            Console.WriteLine($"KeepMetadata: {svgOptions.KeepMetadata}");
            Console.WriteLine($"TextAsShapes: {svgOptions.TextAsShapes}");
            Console.WriteLine("VectorRasterizationOptions (if set):");
            if (svgOptions.VectorRasterizationOptions != null)
            {
                var opt = svgOptions.VectorRasterizationOptions;
                Console.WriteLine($"  BackgroundColor: {opt.BackgroundColor}");
                Console.WriteLine($"  PageSize: {opt.PageSize}");
                Console.WriteLine($"  PageWidth: {opt.PageWidth}");
                Console.WriteLine($"  PageHeight: {opt.PageHeight}");
                Console.WriteLine($"  SmoothingMode: {opt.SmoothingMode}");
                Console.WriteLine($"  TextRenderingHint: {opt.TextRenderingHint}");
            }
            else
            {
                Console.WriteLine("  (null)");
            }
        }

        using (PngOptions pngOptions = new PngOptions())
        {
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.BackgroundColor = Color.White;
            rasterOptions.PageSize = new SizeF(800, 600);
            rasterOptions.SmoothingMode = SmoothingMode.AntiAlias;
            rasterOptions.TextRenderingHint = TextRenderingHint.AntiAlias;
            pngOptions.VectorRasterizationOptions = rasterOptions;

            Console.WriteLine("\nPngOptions properties (output options for PNG):");
            Console.WriteLine($"BitDepth: {pngOptions.BitDepth}");
            Console.WriteLine($"CompressionLevel: {pngOptions.PngCompressionLevel}");
            Console.WriteLine($"Progressive: {pngOptions.Progressive}");
            Console.WriteLine($"FullFrame: {pngOptions.FullFrame}");
            Console.WriteLine($"KeepMetadata: {pngOptions.KeepMetadata}");

            Console.WriteLine("\nVectorRasterizationOptions used for PNG conversion:");
            var opt2 = pngOptions.VectorRasterizationOptions;
            Console.WriteLine($"  BackgroundColor: {opt2.BackgroundColor}");
            Console.WriteLine($"  PageSize: {opt2.PageSize}");
            Console.WriteLine($"  PageWidth: {opt2.PageWidth}");
            Console.WriteLine($"  PageHeight: {opt2.PageHeight}");
            Console.WriteLine($"  SmoothingMode: {opt2.SmoothingMode}");
            Console.WriteLine($"  TextRenderingHint: {opt2.TextRenderingHint}");
        }
    }
}