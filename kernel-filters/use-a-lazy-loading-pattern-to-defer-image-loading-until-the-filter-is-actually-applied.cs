using System;
using System.IO;
using Aspose.Imaging;

class LazyImage : IDisposable
{
    private readonly string _filePath;
    private readonly Lazy<Image> _lazyImage;

    public LazyImage(string filePath)
    {
        _filePath = filePath;
        // Image is not loaded until Value is accessed
        _lazyImage = new Lazy<Image>(() => Image.Load(_filePath));
    }

    // Exposes the underlying Image, loading it on first use
    public Image Image => _lazyImage.Value;

    // Example filter method – place actual processing here
    public void ApplyGrayscale()
    {
        // Accessing Image forces the lazy load
        Image img = Image;
        // Insert grayscale conversion logic if desired
        // For demonstration, we simply ensure the image is loaded
    }

    public void Dispose()
    {
        if (_lazyImage.IsValueCreated)
        {
            Image.Dispose();
        }
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Use lazy‑loading image wrapper
        using (var lazyImg = new LazyImage(inputPath))
        {
            // Apply a filter (loading occurs here)
            lazyImg.ApplyGrayscale();

            // Save the processed image
            lazyImg.Image.Save(outputPath);
        }
    }
}