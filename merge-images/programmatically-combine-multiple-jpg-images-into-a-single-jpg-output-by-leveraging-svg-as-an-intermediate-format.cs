using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files and output JPG file
        string[] inputPaths = new[]
        {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg",
            @"C:\Images\input3.jpg"
        };
        string outputPath = @"C:\Images\combined_output.jpg";

        // Validate each input file existence
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Load each image to obtain dimensions and base64 data
        var imagesInfo = new List<(int Width, int Height, string Base64)>();
        int maxWidth = 0;
        int totalHeight = 0;

        foreach (var inputPath in inputPaths)
        {
            using (Image img = Image.Load(inputPath))
            {
                int w = img.Width;
                int h = img.Height;
                maxWidth = Math.Max(maxWidth, w);
                totalHeight += h;

                byte[] bytes = File.ReadAllBytes(inputPath);
                string base64 = Convert.ToBase64String(bytes);
                imagesInfo.Add((w, h, base64));
            }
        }

        // Build SVG content that stacks images vertically
        var svgBuilder = new System.Text.StringBuilder();
        svgBuilder.AppendLine($@"<svg xmlns=""http://www.w3.org/2000/svg"" width=""{maxWidth}"" height=""{totalHeight}"">");

        int currentY = 0;
        foreach (var info in imagesInfo)
        {
            svgBuilder.AppendLine($@"  <image href=""data:image/jpeg;base64,{info.Base64}"" x=""0"" y=""{currentY}"" width=""{info.Width}"" height=""{info.Height}"" />");
            currentY += info.Height;
        }

        svgBuilder.AppendLine("</svg>");

        // Temporary SVG file path
        string tempSvgPath = @"C:\Images\temp_combined.svg";

        // Ensure directory exists for temporary SVG
        Directory.CreateDirectory(Path.GetDirectoryName(tempSvgPath));

        // Write SVG content to file
        File.WriteAllText(tempSvgPath, svgBuilder.ToString());

        // Load the SVG image
        using (Image svgImage = Image.Load(tempSvgPath))
        {
            // Prepare JPEG save options (default)
            var jpegOptions = new JpegOptions();

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the rasterized SVG as a JPEG
            svgImage.Save(outputPath, jpegOptions);
        }

        // Optionally delete the temporary SVG file
        try
        {
            File.Delete(tempSvgPath);
        }
        catch
        {
            // Ignored – cleanup failure should not affect the main result
        }
    }
}