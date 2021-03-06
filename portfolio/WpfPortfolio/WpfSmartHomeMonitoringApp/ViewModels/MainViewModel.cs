using Caliburn.Micro;
using System;
using System.Threading;
using System.Threading.Tasks;
using WpfSmartHomeMonitoringApp.Helpers;

namespace WpfSmartHomeMonitoringApp.ViewModels
{
    public class MainViewModel : Conductor<object>      //Screen에는 ActivateItem[Async] 메서드 없음
    {
        public MainViewModel()
        {
            DisplayName = "SmartHome Monitoring v2.0";      //윈도우 타이틀, 제목
        }

        protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            if(Commons.MQTT_CLIENT.IsConnected)
            {
                Commons.MQTT_CLIENT.Disconnect();
                Commons.MQTT_CLIENT = null;
            }//비활성화 처리

            return base.OnDeactivateAsync(close, cancellationToken);
        }

        public void LoadDataBaseView()
        {
            ActivateItemAsync(new DataBaseViewModel());
        }

        public void LoadRealTimeView()
        {
            ActivateItemAsync(new RealTimeViewModel());
        }

        public void LoadHistoryView()
        {
            ActivateItemAsync(new HistoryViewModel());
        }

        public void ExitProgram()
        {
            Environment.Exit(0);        //프로그램 종료
        }

        public void ExitToolbar()
        {
            Environment.Exit(0);        //프로그램 종료
        }

        //Start 메뉴, 아이콘 눌렀을 때 처리할 이벤트
        public void PopInfoDialog()
        {
            TaskPopup();
        }

        public void StartSubscribe()
        {
            TaskPopup();
        }

        private void TaskPopup()
        {
            //CustomPopupView
            var winManager = new WindowManager();
            var result = winManager.ShowDialogAsync(new CustomPopupViewModel("New Broker"));

            if (result.Result == true)
            {
                ActivateItemAsync(new DataBaseViewModel());    //화면전환
            }
        }

        public void PopInfoView()
        {
            var winManager = new WindowManager();
            winManager.ShowDialogAsync(new CustomInfoViewModel("About"));
        }

        public void MenuStop()
        {
            ActivateItemAsync(new DataBaseViewModel()); //화면전환
            StopSubscribe();                            //화면 정지 & 초기화
        }

        public void ToolbarStopSubscribe()
        {
            ActivateItemAsync(new DataBaseViewModel()); //화면전환
            StopSubscribe();                            //화면 정지 & 초기화
        }

        public void StopSubscribe()
        {
            if(this.ActiveItem is DataBaseViewModel)
            {
                DataBaseViewModel activeModel = (this.ActiveItem as DataBaseViewModel);
                try
                {
                    if(Commons.MQTT_CLIENT.IsConnected)
                    {
                        Commons.MQTT_CLIENT.MqttMsgPublishReceived -= activeModel.MQTT_CLIENT_MqttMsgPublishReceived;
                        Commons.MQTT_CLIENT.Disconnect();
                        activeModel.IsConnected = Commons.IS_CONNECT = false;
                    }
                }
                catch (Exception ex)
                {

                }
                DeactivateItemAsync(this.ActiveItem, true);
            }
        }
    }
}
