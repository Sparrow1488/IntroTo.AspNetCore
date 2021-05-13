using _4.ConveyorOfRequestProcessing.middlewares;
using Microsoft.AspNetCore.Builder;

namespace _4.ConveyorOfRequestProcessing
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            /*
             *  ���� � ���, ��� �� �� ����� �������� ��������� �����, ���� �� ������������
             *  �.�., �� ������ � �������� �������� ������� ������
             *  ��������: /home?password=1488
             */
            app.UseMiddleware<AuthMiddleware>();
            app.UseMiddleware<RoutingMiddleware>();

            // ����������� ��������� - https://metanit.com/sharp/aspnet5/pics/2.20.png
        }
    }
}
