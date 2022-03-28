using System.Text;
using UserProductMinimal.Enum;

namespace UserProductMinimal.Service
{
    public class HttpClientService
    {
        public string OnRequest(EHttpVerbs httpVerbs, string uri, StringBuilder strDados)
        {
            try
            {
                string strURI = string.Empty;
                var request = new HttpRequestMessage();

                request.Headers.Add("Accept-Encoding", "gzip, deflate");

                switch (httpVerbs)
                {
                    case EHttpVerbs.POST:
                        strURI += uri;
                        request.Method = HttpMethod.Post;
                        request.Content = new StringContent(strDados.ToString(), Encoding.UTF8, "application/json");

                        break;
                    case EHttpVerbs.GET:
                        strURI += uri;
                        request.Method = HttpMethod.Get;
                        if ((strDados != null) && (strDados.ToString() != string.Empty))
                        {
                            strURI += strDados.ToString();
                        }
                        else
                        {
                            return ($"Parâmetro QUERY STRING Obrigatório.");
                        }

                        break;
                    case EHttpVerbs.PUT:
                        request.Method = HttpMethod.Put;
                        break;
                    case EHttpVerbs.DELETE:
                        request.Method = HttpMethod.Delete;
                        break;
                }

                Stream streamRet;
                using (var client = new HttpClient())
                {
                    Uri myUri = new Uri(strURI);

                    client.Timeout = System.TimeSpan.FromSeconds(60);
                    request.RequestUri = myUri;

                    HttpResponseMessage? response = client.Send(request);

                    if (response.IsSuccessStatusCode)
                    {

                        streamRet = response.Content.ReadAsStream();
                        StreamReader streamReader = new StreamReader(streamRet);
                        return streamReader.ReadToEnd();
                    }
                    else
                    {

                        return ($"ERRO HTTP: {response.StatusCode} - Falha ao enviar requisição.");
                    }
                }
            }
            catch (Exception ex)
            {
                return ($"ERRO: {ex.Message}");
            }
        }
    }
}
