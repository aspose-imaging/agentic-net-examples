using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output root directories
            string inputRoot = @"C:\InputImages";
            string outputRoot = @"C:\OutputPdfs";

            // Ensure the output root exists
            Directory.CreateDirectory(outputRoot);

            // Process each subfolder in the input root
            foreach (string folderPath in Directory.GetDirectories(inputRoot))
            {
                // Build a simple output PDF file name based on the folder name
                string folderName = new DirectoryInfo(folderPath).Name;
                string outputPdfPath = Path.Combine(outputRoot, folderName + ".pdf");

                // Get all JPEG files in the current folder
                string[] jpegFiles = Directory.GetFiles(folderPath, "*.jpg");
                string[] jpegFilesUpper = Directory.GetFiles(folderPath, "*.jpeg");
                string[] allJpegFiles = new string[jpegFiles.Length + jpegFilesUpper.Length];
                jpegFiles.CopyTo(allJpegFiles, 0);
                jpegFilesUpper.CopyTo(allJpegFiles, jpegFiles.Length);

                if (allJpegFiles.Length == 0)
                {
                    // No images to process in this folder
                    continue;
                }

                // Load images and collect dimensions
                var images = new RasterImage[allJpegFiles.Length];
                int totalWidth = 0;
                int maxHeight = 0;

                for (int i = 0; i < allJpegFiles.Length; i++)
                {
                    string imgPath = allJpegFiles[i];

                    if (!File.Exists(imgPath))
                    {
                        Console.Error.WriteLine($"File not found: {imgPath}");
                        return;
                    }

                    images[i] = (RasterImage)Image.Load(imgPath);
                    totalWidth += images[i].Width;
                    if (images[i].Height > maxHeight)
                        maxHeight = images[i].Height;
                }

                // Create a blank canvas to hold the merged image
                using (RasterImage merged = (RasterImage)Image.Create(new PngOptions(), totalWidth, maxHeight))
                {
                    // Draw each image side by side
                    var graphics = new Graphics(merged);
                    int offsetX = 0;
                    foreach (var img in images)
                    {
                        graphics.DrawImage(img, offsetX, 0);
                        offsetX += img.Width;
                    }

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

                    // Save the merged image as a PDF
                    merged.Save(outputPdfPath, new PdfOptions());
                }

                // Dispose loaded images
                foreach (var img in images)
                {
                    img.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}