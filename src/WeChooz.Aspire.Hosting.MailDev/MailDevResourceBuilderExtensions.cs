using Aspire.Hosting.ApplicationModel;

using WeChooz.Aspire.Hosting.MailDev;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Aspire.Hosting;
#pragma warning restore IDE0130 // Namespace does not match folder structure
/// <summary>
/// Provides extension methods for adding MailDev to an <see cref="IDistributedApplicationBuilder"/>.
/// </summary>
public static class MailDevResourceBuilderExtensions
{
    /// <summary>
    /// Adds the <see cref="MailDevResource"/> to the given <paramref name="builder"/> instance. Uses the "2.2.1" tag.
    /// </summary>
    /// <param name="builder">The <see cref="IDistributedApplicationBuilder"/> to which the MailDev resource will be added.</param>
    /// <param name="name">The name of the MailDev container resource.</param>
    /// <param name="httpPort">Optional. The HTTP port on which MailDev will listen (to see the mails).</param>
    /// <param name="smtpPort">Optional. The SMTP port on which MailDev will listen.</param>
    /// <param name="credentials"></param>
    /// <returns>
    /// An <see cref="IResourceBuilder{MailDevResource}"/> instance that
    /// represents the added MailDev resource.
    /// </returns>
    public static IResourceBuilder<MailDevResource> AddMailDev(
        this IDistributedApplicationBuilder builder,
        string name,
        int? httpPort = null,
        int? smtpPort = null,
        CredentialsResourceParameterBuilder? credentials = null)
    {
        var resource = new MailDevResource(name, credentials == null ? null : new(credentials.Username.Resource, credentials.Password.Resource));

        var mailDevResourceBuilder = builder.AddResource(resource)
                      .WithImage(MailDevContainerImageTags.Image)
                      .WithImageRegistry(MailDevContainerImageTags.Registry)
                      .WithImageTag(MailDevContainerImageTags.Tag)
                      .WithHttpEndpoint(
                          targetPort: 1080,
                          port: httpPort,
                          name: MailDevResource.HttpEndpointName,
                          isProxied: false)
                      .WithEndpoint(
                          targetPort: 1025,
                          port: smtpPort,
                          name: MailDevResource.SmtpEndpointName,
                          isProxied: false);
        if (credentials != null && resource.Credentials != null)
        {
            mailDevResourceBuilder
                      .WithEnvironment(context =>
                      {
                          context.EnvironmentVariables[MailDevContainerImageTags.UserEnvVarName] = resource.Credentials.Username;
                          context.EnvironmentVariables[MailDevContainerImageTags.PasswordEnvVarName] = resource.Credentials.Password;
                      });
        }
        return mailDevResourceBuilder;
    }
}
