using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Crycker.Helper
{
    public class UpdateCheckHelper
    {
        private string Owner { get; set; }
        private string Repo { get; set; }

        public string LatestVersionUrl
        {
            get
            {
                return $"https://github.com/{Owner}/{Repo}/releases/latest";
            }
        }

        public UpdateCheckHelper(string owner, string repo)
        {
            Owner = owner;
            Repo = repo;         
        }

        public async Task<string> UpdateAvailable()
        {
            try
            {
                var latest = await GetLatestVersionFromGithub();
                var current = GetCurrentVersion();

                if (latest > current)
                {
                    return latest.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Update check failed", ex);
                return null;
            }
        }

        private async Task<Version> GetLatestVersionFromGithub()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var jsonData = await client.GetStreamAsync($"https://api.github.com/repos/{Owner}/{Repo}/releases/latest");

            var serializer = new DataContractJsonSerializer(typeof(GitHubRelease));
            var latestRelease = (GitHubRelease)serializer.ReadObject(jsonData);

            var latestVersion = new Version(latestRelease.tag_name.Replace("v", ""));

            return latestVersion;
        }

        public Version GetCurrentVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var verionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            var currentVersion = new Version(verionInfo.ProductVersion);

            return currentVersion;
        }
    }

    public class GitHubRelease
    {
        public string url { get; set; }
        //public string assets_url { get; set; }
        //public string upload_url { get; set; }
        //public string html_url { get; set; }
        public int id { get; set; }
        public string tag_name { get; set; }
        //public string target_commitish { get; set; }
        public string name { get; set; }
        //public bool draft { get; set; }
        //public Author author { get; set; }
        public bool prerelease { get; set; }
        //public DateTime created_at { get; set; }
        public string published_at { get; set; }
        //public List<Asset> assets { get; set; }
        //public string tarball_url { get; set; }
        //public string zipball_url { get; set; }
        //public string body { get; set; }
    }
}
