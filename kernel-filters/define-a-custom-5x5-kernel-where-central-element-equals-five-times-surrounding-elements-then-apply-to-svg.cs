// HOW-TO: Apply Custom 5x5 Convolution Kernel to SVG Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;

namespace SvgKernelApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.svg";
                string outputPath = "output/output.svg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                string svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg xmlns=""http://www.w3.org/2000/svg"" width=""200"" height=""200"">
  <defs>
    <filter id=""customKernel"">
      <feConvolveMatrix order=""5 5"" kernelMatrix=""1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 5"" divisor=""29"" bias=""0""/>
    </filter>
  </defs>
  <rect x=""10"" y=""10"" width=""180"" height=""180"" fill=""red"" filter=""url(#customKernel)""/>
</svg>";

                File.WriteAllText(outputPath, svgContent);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to enhance or blur an SVG graphic by applying a custom convolution filter directly in C#.
 * 2. When you want to programmatically generate an SVG file with a filter that emphasizes the center pixel relative to its neighbors.
 * 3. When you need to automate batch processing of SVG assets to apply a consistent visual effect before publishing to a website.
 * 4. When you are building a .NET application that must create SVG images with embedded filters without using external image editors.
 * 5. When you require a reproducible way to test how different kernel matrices affect SVG rendering for UI design experiments.
 */
