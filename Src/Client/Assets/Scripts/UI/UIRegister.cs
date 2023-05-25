using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Services;

public class UIRegister : MonoBehaviour {

    public InputField username;
    public InputField password;
    public InputField passwordConfirm;
    public Button buttonRegister;


    // Use this for initialization
    void Start () {
        UserService.Instance.OnRegister = this.OnRegister;  //逻辑层需要间接调用UI层即通过事件注册调用，这里注册OnRegister函数给逻辑层调用，用于输出提示结果

    }
	
    void OnRegister(SkillBridge.Message.Result result, string msg)
    {
        MessageBox.Show(string.Format("结果：{0} msg:{1}",result,msg));
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickRegister()   //button组件触发的事件，需要在unity的button组件中增加该函数
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
        if (string.IsNullOrEmpty(this.passwordConfirm.text))
        {
            MessageBox.Show("请输入确认密码");
            return;
        }
        if (this.password.text != this.passwordConfirm.text)
        {
            MessageBox.Show("两次输入的密码不一致");
            return;
        }
        UserService.Instance.SendRegister(this.username.text, this.password.text);  //UI层可直接调用逻辑层，直接将收到的数据发送给逻辑层处理
    }
}
