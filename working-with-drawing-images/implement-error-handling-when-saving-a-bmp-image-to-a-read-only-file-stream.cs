// HOW-TO: How To Save JPEG As BMP To A Read‑Only Stream In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(outputPath))
            {
                File.WriteAllBytes(outputPath, new byte[0]);
            }

            using (Image image = Image.Load(inputPath))
            {
                using (FileStream readOnlyStream = new FileStream(outputPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    BmpOptions options = new BmpOptions();
                    image.Save(readOnlyStream, options);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert user‑uploaded JPEG photos to BMP format while writing to a file that is opened as read‑only for security compliance.
 * 2. When an application must generate BMP thumbnails from JPEG images but the destination file is locked for writing by another process.
 * 3. When you are processing images in a sandboxed environment where the output stream can only be opened with read access.
 * 4. When you want to gracefully handle permission errors while saving converted images to a network share that enforces read‑only access.
 * 5. When you need to log or display conversion failures without crashing the program by catching exceptions during the save operation.
 */
