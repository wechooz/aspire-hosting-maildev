#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Aspire.Hosting;

// This class just contains constant strings that can be updated periodically
// when new versions of the underlying container are released.
internal static class MailDevContainerImageTags
{
    internal const string Registry = "docker.io";

    internal const string Image = "maildev/maildev";

    internal const string Tag = "2.2.1";
    internal const string UserEnvVarName = "MAILDEV_INCOMING_USER";
    internal const string PasswordEnvVarName = "MAILDEV_INCOMING_PASS";
}
