namespace Patterns.Facade
{
    public class FileUploadFacade
    {
        private readonly FileUploader _uploader;
        private readonly FileCompressor _compressor;
        public FileUploadFacade(FileUploader uploader, FileCompressor compressor)
        {
            _uploader = uploader;
            _compressor = compressor;
        }
        public void Upload()
        {
            _compressor.Compress();
            _uploader.Upload();
        }
    }
}