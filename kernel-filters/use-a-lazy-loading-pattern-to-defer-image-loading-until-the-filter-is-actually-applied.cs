using System;
using System.IO;
using Aspose.Imaging;

class LazyImage : IDisposable
{
    private readonly string _filePath;
    private Image _image;

    public LazyImage(string filePath)
    {
        _filePath = filePath;
    }

    // Loads the image only when an operation is requested
    public void Apply(Action<Image> operation)
    {
        if (_image == null)
        {
            // Verify that the image can be loaded before attempting to load it
            if (!Image.CanLoad(_filePath))
                throw new InvalidOperationException($"Cannot load image from {_filePath}");

            // Load the image lazily
            _image = Image.Load(_filePath);
        }

        // Perform the supplied operation on the loaded image
        operation(_image);
    }

    public void Dispose()
    {
        _image?.Dispose();
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";

        // Path‑safety checks as required
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Use lazy loading – the image is not loaded until the filter is applied
            using (var lazyImage = new LazyImage(inputPath))
            {
                // Example filter: simply save the image (replace with real processing as needed)
                lazyImage.Apply(img => img.Save(outputPath));
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}