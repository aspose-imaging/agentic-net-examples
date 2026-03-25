using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class CustomSvgCallback : SvgResourceKeeperCallback
{
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Convert the SVG byte data to a string.
        string svgContent = System.Text.Encoding.UTF8.GetString(htmlData);

        // Prepare a custom XML comment describing the conversion.
        string comment = "<!-- Converted from BMP to SVG using Aspose.Imaging -->\n";

        // Insert the comment after the XML declaration if it exists.
        int insertPos = svgContent.IndexOf("?>");
        if (insertPos != -1)
        {
            insertPos += 2; // Move past the declaration.
            svgContent = svgContent.Insert(insertPos, "\n" + comment);
        }
        else
        {
            svgContent = comment + svgContent;
        }

        // Ensure the target directory exists.
        string dir = Path.GetDirectoryName(suggestedFileName);
        if (!string.IsNullOrEmpty(dir))
        {
            Directory.CreateDirectory(dir);
        }

        // Write the modified SVG content to the suggested file name.
        File.WriteAllText(suggestedFileName, svgContent);
        return suggestedFileName;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths.
        string inputPath = "input/input.bmp";
        string outputPath = "output/output.svg";

        // Verify that the input file exists.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists before saving.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image.
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options to match the source image size.
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set up SVG save options with the custom callback.
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                Callback = new CustomSvgCallback()
            };

            // Save the image as SVG; the callback will embed the comment.
            image.Save(outputPath, svgOptions);
        }
    }
}