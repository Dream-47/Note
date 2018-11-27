using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoteTest
{
    /// <summary>
    /// 委托测试
    /// </summary>
    class DelTest
    {
        //简单委托
        //委托的实质:委托实质上是一个类，区别于普通类，他的成员是一个方法，他的特征是返回值与输入参数
        //委托的作用:
        //1.只定义方法的输入参数与返回值类型，不定义具体实现过程，将这些具体的方法当做参数来传递
        //2.委托链:委托类对象可以通过+=添加方法链，当输入参数时，将从上往下执行方法列表。           

        //声明一个委托类
        public delegate void TestDel(string str);
        //声明一个与委托类符合的实例方法
        public static void Eat(string food)
        {
            Console.WriteLine("eat " + food);
        }
        public static void Say(string msg)
        {
            Console.WriteLine("say " + msg);
        }


        //泛型委托
        //声明一个参数与返回值相同的委托
        //<T>表示参数以及返回值的类型，如果参数不一样要写做<T1,T2>
        
        public delegate T Caculate<T>(T arg1,T arg2);
        //声明一些符合委托类型实例的方法
        public static int Add(int a, int b)
        {
            Console.WriteLine("result:" + (a + b));
            return a + b;          
        }

        public static int CompareBigger(int a ,int b)
        {
            var c= a > b ? a : b;
            Console.WriteLine("bigger is:" + c);
            return c;           
        }

        //Func Action委托
        //通用委托，系统定义好的委托，能满足几乎所有情况
        //Action:返回值为空，输入参数为多个泛型重载
        //Func:返回值为泛型，输入参数为多个泛型重载
        //public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
        //delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);

        static void Main(string[] args)
        {
            //------------------------简单委托测试----------------------
            //声明委托类的对象并且实例化(有三种方式)
            //TestDel handle = new TestDel(Eat);
            TestDel handle = Eat; 
            //TestDel handle = null;
            //handle += Eat;
            //调用对象中方法
            handle("orange");
            handle += Say;
            handle("pink");
            Console.ReadKey();

            //-------------------- 泛型委托测试-------------------------
            //声明并且实例化
            //泛型委托声明时需要声明泛型类型
            Caculate<int> caculate = Add;
            caculate += CompareBigger;
            caculate(3, 4);
            Console.ReadKey();

            //-------------------通用委托测试-----------------
            Action<string> action = Say;
            action("hello");
            Func<int,int,int> func = CompareBigger;
            func(4, 3);
            Console.ReadKey();
        }
    }
}
