using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input EPS files and corresponding output PNG files
        string[] inputPaths = { "input1.eps", "input2.eps", "input3.eps" };
        string[] outputPaths = { "output1.png", "output2.png", "output3.png" };

        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate new dimensions with a scaling factor of 1.5
                int newWidth = (int)(image.Width * 1.5);
                int newHeight = (int)(image.Height * 1.5);

                // Resize the image (Lanczos provides good quality for scaling)
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Save as PNG preserving transparency
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
    }
}