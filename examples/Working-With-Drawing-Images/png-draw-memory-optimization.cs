using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Output file path for the generated PNG
        string outputPath = "graphics_complex.png";

        // Desired image dimensions
        const int imageSize = 2000;

        // Configure PNG creation options with a memory limit (30 MB)
        PngOptions createOptions = new PngOptions
        {
            // The file will be created when the image is saved
            Source = new FileCreateSource(outputPath, false),
            // Limit internal buffers to 30 megabytes
            BufferSizeHint = 30
        };

        // Create a new PNG image using the options above
        using (Image image = Image.Create(createOptions, imageSize, imageSize))
        {
            // Obtain a Graphics object for drawing operations
            Graphics graphics = new Graphics(image);

            // Begin a batch update to keep memory usage low
            graphics.BeginUpdate();

            // Fill the background with a light color
            graphics.Clear(Color.LightSkyBlue);

            const int operationAreaSize = 10;
            int numberOfOperations = 0;

            // Perform a large number of line drawing operations.
            // Because of BeginUpdate/EndUpdate and the BufferSizeHint,
            // the operations are streamed to the file and do not consume excessive RAM.
            for (int column = 0; column * operationAreaSize < imageSize; column++)
            {
                for (int row = 0; row * operationAreaSize < imageSize; row++)
                {
                    int x = column * operationAreaSize;
                    int y = row * operationAreaSize;

                    bool reversed = (column + row) % 2 != 0;
                    Pen pen = new Pen(Color.Red);

                    if (reversed)
                    {
                        graphics.DrawLine(pen, x + operationAreaSize - 2, y, x, y + operationAreaSize);
                    }
                    else
                    {
                        graphics.DrawLine(pen, x, y, x + operationAreaSize - 2, y + operationAreaSize);
                    }

                    numberOfOperations++;
                }
            }

            // End the batch update; all pending operations are flushed to the file
            graphics.EndUpdate();

            // Save the image data to the file specified in the source
            image.Save();
        }
    }
}