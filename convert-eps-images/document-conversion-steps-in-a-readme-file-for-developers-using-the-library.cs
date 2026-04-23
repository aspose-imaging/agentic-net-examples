using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input, output, and README file paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.jpg";
        string readmePath = @"C:\temp\README.md";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the directories for output and README exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(readmePath));

        // Load the source image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Prepare JPEG options for the target format
            var jpegOptions = new JpegOptions();

            // Save the image to the output path with the specified options
            image.Save(outputPath, jpegOptions);
        }

        // Build the README content that documents the conversion steps
        var sb = new StringBuilder();
        sb.AppendLine("# Image Conversion Guide");
        sb.AppendLine();
        sb.AppendLine("This guide demonstrates how to use Aspose.Imaging to convert an image from PNG to JPEG.");
        sb.AppendLine();
        sb.AppendLine("## Steps");
        sb.AppendLine("1. **Load the source image** using `Image.Load`.");
        sb.AppendLine("2. **Create the appropriate options** for the target format (e.g., `JpegOptions`).");
        sb.AppendLine("3. **Save the image** to the desired output path with `image.Save(outputPath, options)`. ");
        sb.AppendLine("4. Ensure the output directory exists before saving.");
        sb.AppendLine();
        sb.AppendLine($"**Input file:** `{inputPath}`");
        sb.AppendLine($"**Output file:** `{outputPath}`");

        // Write the README file to disk
        File.WriteAllText(readmePath, sb.ToString());

        Console.WriteLine("Conversion completed and README generated.");
    }
}