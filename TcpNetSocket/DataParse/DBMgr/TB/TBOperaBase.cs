using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

/// <summary>
/// 数据表基类
/// </summary>  
public class TBOperaBase<T> where T: new () {

    private static T instance;

    public static T Instance {
        get {
            if (instance == null) {
                
                instance = new T();
            }
            return instance;
        }
    }

    /// <summary>
    /// 保存时间
    /// </summary>
    protected string SaveTime { get; set; }
    /// <summary>
    /// 表字段
    /// </summary>
    protected string Field { get; set; }
    /// <summary>
    /// 表数据
    /// </summary>
    protected string Data { get; set; }

    /// <summary>
    /// 插入数据
    /// </summary>
    public virtual void Insert() {
        
    }

    /// <summary>
    /// 查询数据库
    /// </summary>
    public virtual void Query() {

    }

    /// <summary>
    /// 删除数据
    /// </summary>
    public virtual void Delete() {

    }

    /// <summary>
    /// 更新数据
    /// </summary>
    public virtual void Update() {

    }

    

}

