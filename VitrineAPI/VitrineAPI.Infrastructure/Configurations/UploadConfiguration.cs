using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Infrastructure.Configurations.Base;

namespace VitrineAPI.Infrastructure.Configurations
{
    public class UploadConfiguration : ConfigurationUploadFormBase<Upload>
    {
        public override void Configure(EntityTypeBuilder<Upload> builder)
        {
            tableName = "Uploads";
            base.Configure(builder);
        }
    }
}