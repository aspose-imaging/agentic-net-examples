using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPEG file paths
        string[] inputPaths = new string[]
        {
            @"C:\temp\input1.jpg",
            @"C:\temp\input2.jpg"
        };

        // Hard‑coded temporary folder for intermediate saves
        string tempFolder = @"C:\temp\merged_temp";

        // Hard‑coded final destination folder
        string finalFolder = @"C:\temp\merged_final";

        // Ensure the temporary and final folders exist
        Directory.CreateDirectory(tempFolder);
        Directory.CreateDirectory(finalFolder);

        // Process each input image
        foreach (string inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Example processing: no change, just re‑save
                // Build temporary output path (same file name in temp folder)
                string tempOutputPath = Path.Combine(tempFolder, Path.GetFileName(inputPath));

                // Ensure the directory for the output path exists (already created above)
                Directory.CreateDirectory(Path.GetDirectoryName(tempOutputPath));

                // Save the image to the temporary location as JPEG
                JpegOptions jpegOptions = new JpegOptions(); // default options
                image.Save(tempOutputPath, jpegOptions);
            }
        }

        // Verification: ensure all temporary files were created
        foreach (string inputPath in inputPaths)
        {
            string tempOutputPath = Path.Combine(tempFolder, Path.GetFileName(inputPath));
            if (!File.Exists(tempOutputPath))
            {
                Console.Error.WriteLine($"Failed to create temporary file: {tempOutputPath}");
                return;
            }
        }

        // Move verified temporary files to the final destination
        foreach (string inputPath in inputPaths)
        {
            string fileName = Path.GetFileName(inputPath);
            string tempFile = Path.Combine(tempFolder, fileName);
            string finalFile = Path.Combine(finalFolder, fileName);

            // Ensure the final directory exists (already created above)
            Directory.CreateDirectory(Path.GetDirectoryName(finalFile));

            // Overwrite if the file already exists at the destination
            if (File.Exists(finalFile))
            {
                File.Delete(finalFile);
            }

            File.Move(tempFile, finalFile);
        }

        Console.WriteLine("All images have been merged (saved) and moved to the final destination.");
    }
}