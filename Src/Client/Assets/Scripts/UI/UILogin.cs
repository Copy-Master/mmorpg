using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Services;

public class UILogin : MonoBehaviour {

    public InputField username;
    public InputField password;
    public Button buttonLogin;


    // Use this for initialization
    void Start () {
        UserService.Instance.OnLogin = this.OnLogin;  //逻辑层需要间接调用UI层即通过事件注册调用，这里注册函数给逻辑层调用，用于输出提示结果

    }
	
    void OnLogin(SkillBridge.Message.Result result, string msg)
    {
        MessageBox.Show(string.Format("结果：{0} msg:{1}",result,msg));
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickLogin()   //button组件触发的事件，需要在unity的button组件中增加该函数
    {
        if (string.IsNullOrEmpty(this.username.text))
        {
            MessageBox.Show("请输入账号");
            return;
        }
        if (string.IsNullOrEmpty(this.password.text))
        {
            MessageBox.Show("请输入密码");
            return;
        }
        UserService.Instance.SendLogin(this.username.text, this.password.text);  //UI层可直接调用逻辑层，直接将收到的数据发送给逻辑层处理
    }
}
