# 0. WPF Style이란?

### WPF

- WPF는 윈도우 프레젠테이션 파운데이션(Windows Presentation Foundation)으로, 윈도우 기반 응용프로그램에서 사용자 인터페이스를 표시하기 위한 목적으로 마이크로소프트에서 만든 그래픽 서브시스템이다.
  - Windows Presentation Foundation은 데스크톱 클라이언트 애플리케이션을 만드는 UI 프레임워크이다.
  - WPF 개발 플랫폼은 애플리케이션 모델, 리소스, 컨트롤, 그래픽, 레이아웃, 데이터 바인딩, 문서 및 보안을 포함하여 다양한 애플리케이션 개발 기능 세트를 지원한다.
- WPF는 다양한 인터페이스 요소들을 정의하고 연결하기 위해 [+XML 기반의 언어인 XAML+]을 채용하였다.
  - XAML(Extensible Application Markup Language)
- WPF 응용프로그램은 데스크탑에서 단독으로 실행될 수도 있고 [+웹사이트에 내장된 객체로 서비스될 수도 있다.+]
- WPF는 2D/3D 렌더링, 고정 및 가변 문서, 타이포그래피, 벡터 그래픽스, 실시간 애니메이션, 프리렌더링 미디어와 같은 [+여러 가지 보편적인 사용자 인터페이스들을 통합하는 것을 목적+]으로 한다.

### WPF Style이란?

- XAML의 Resource절은 객체를 참조할 때도 사용되지만 Style 객체를 정의하는데도 이용된다. Style은 Element에 적용되는 스타일 프로퍼티의 집합이다.
- XAML 안에서 프로그래밍 언어처럼 반복문을 사용할 수 없으므로 동일한 프로퍼티를 가지는 여러 요소들을 생성할 때 사용하면 좋다.
- 페이지에 버튼이 많다고 가정할 떄 Margin,Font 등의 속성은 비슷하게 이용되므로 Resource절 내에 style로 정의하면 공용으로 사용할 수 있다.
- 웹페이지에 적용되는 style가 비교했을 때 WPF의 style은 다른 프로퍼티의 변화 또는 이벤트로부터 유발되는 프로퍼티의 변화를 제어할 수 있기에 더욱 강력하다.
- object를 상속받은 style은 System.Window에 정의되어 있으며 중요한 프로퍼티는 Setter로 SetterBase 객체(Setter와 EventSetter가 상속받음)의 컬렉션인 SetterBaseCollection 타입의 프로퍼티로 이를 통해 프로퍼티나 이벤트 핸들러를 설정할 수 있다.
- Setter는 style의 컨텐트프로퍼티로 Setter와 EventSetter는 style요소의 자식이며 일반적으로 setter가 더 많이 사용된다.
- setter는 특정 프로퍼티와 값을 연결시키며 프로퍼티 타입과 value타입 2개의 프로퍼티가 있다.
- Property의 값은 항상 의존프로퍼티를 참조
  - 보통 속성앞에 정의했거나 상속한 클래스의 이름을 명시한다.
  - 만약 null값을 Value속성에 대입하려면 x:Null을 사용한다.
  ```xml
  <Style...>
      <Setter Property="Control.FontSize" Value="12"/>
      <EventSetter .../>
      <Setter Property="Control.FontSize" Value="{x:Null}"/>
  </Style>
  ```
- 로컬요소를 위한 Style 요소를 정의하는것도 가능하다.
- FramwworkElement는 Style 속성을 가지고 있으며 버튼이 이를 상속 받앗으므로 Style 요소를 내부에 정의 할 수 있다.
- 버튼의 전경색을 Button 요소, Setter를 이용하여 두번 정의 했는데 Button 요소에서 정의한 것이 우선 적용된다.
  ```xml
  <Button HorizontalAlignment="Center" VerticalAlignment="Center" Foreground="Blue">
     <Button.Style>
        <Style>
           <Setter Property="Button.FontSize" Value="16pt"/>
           <Setter Property="Button.FontWeight" Value="Bold"/>
           <Setter Property="Button.FontFamil" Value="Constantia"/>
           <Setter Property="Control.Foreground" Value="Red"/>
        </Style>
     </Button.Style>
  </Button>
  ```
- 대부분 여러 개의 요소와 컨트롤들이 공유 가능하도록 Style을 Resource절에 사용하고 있으며 Application 객체의 Resource절에서 사용한 Style은 전체 응용프로그램에서 공용 사용 가능하다.
- 예시
  ```xml
  <StackPanel>
     <StackPanel.Resources>
        <Style x:Key="normaal">
           <Setter Property="Control.FontSize" Value="22"/>
           <Setter Property="Control.Foreground" Value="Red"/>
           <Setter Property="Control.HorizontalAlignment" Value="Center"/>
           <Setter Property="Control.Margin" Value="30"/>
           <Setter Property="Control.Padding" Value="20, 10, 20, 10"/>
        </Style>
     </StackPanel.Resources>
     <Button Style="{StaticResource normal}">
        버튼 테스트1
     </Button>
     <TextBlock Style="{StaticResource normal}">
        텍스트 블록 테스트
     </TextBlock>
     <Button Style="{StaticResource normal}">
        버튼 테스트2
     </Button>
  </StackPanel>
  ```


### 출처

- [Microsoft - WPF](https://docs.microsoft.com/ko-kr/visualstudio/designers/getting-started-with-wpf?view=vs-2022)
- [Wikipedia - WPF](https://ko.wikipedia.org/wiki/윈도우_프레젠테이션_파운데이션)
- [WPF Style이란?](https://velog.io/@s00ny0ung/WPF-%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%98%EB%B0%8D-1.-WPF-Style%EC%9D%B4%EB%9E%80)

<br><br><br>
