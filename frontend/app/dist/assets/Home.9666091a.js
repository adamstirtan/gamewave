import{k as it,b as be,c as _e,d as Ce,m as I,f as we,g as Se,h as ke,a as R,l as xe,n as Le,o as oe,u as ot,p as lt,q as rt,j as V,i as M,r as ut,V as ct}from"./VIcon.0564a482.js";import{V as le,p as S,P as G,c as f,s as l,N as dt,Z as re,t as X,l as E,v as q,w as ft,u as x,g as Ee,d as vt,e as Ve,i as mt,j as K,G as J,a as gt,y as pt,o as ht,_ as yt,$ as bt,k as _t,a0 as Ct,z as wt,r as H,S as St,b as kt,a1 as xt,a2 as Lt,a3 as ue,F as Et,a4 as Vt,a5 as ce,K as It,W as de,L as Tt,M as $t,a6 as O,a7 as Z,n as Ie,A as Te,B as $e,C as k,D,a8 as Q}from"./index.332ef7f5.js";const Pt=["top","bottom"],Bt=["start","end","left","right"];function Nt(e,t){let[n,s]=e.split(" ");return s||(s=le(Pt,n)?"start":le(Bt,n)?"top":"center"),{side:fe(n,t),align:fe(s,t)}}function fe(e,t){return e==="start"?t?"right":"left":e==="end"?t?"left":"right":e}const Rt=[null,"default","comfortable","compact"],Pe=S({density:{type:String,default:"default",validator:e=>Rt.includes(e)}},"density");function Be(e){let t=arguments.length>1&&arguments[1]!==void 0?arguments[1]:G();return{densityClasses:f(()=>`${t}--density-${e.density}`)}}const At=["elevated","flat","tonal","outlined","text","plain"];function jt(e,t){return l(dt,null,[e&&l("span",{key:"overlay",class:`${t}__overlay`},null),l("span",{key:"underlay",class:`${t}__underlay`},null)])}const Ne=S({color:String,variant:{type:String,default:"elevated",validator:e=>At.includes(e)}},"variant");function Gt(e){let t=arguments.length>1&&arguments[1]!==void 0?arguments[1]:G();const n=f(()=>{const{variant:i}=re(e);return`${t}--variant-${i}`}),{colorClasses:s,colorStyles:a}=it(f(()=>{const{variant:i,color:o}=re(e);return{[["elevated","flat"].includes(i)?"background":"text"]:o}}));return{colorClasses:s,colorStyles:a,variantClasses:n}}const Re=S({divided:Boolean,...be(),...Pe(),..._e(),...Ce(),...I(),...X(),...Ne()},"v-btn-group"),ve=E()({name:"VBtnGroup",props:Re(),setup(e,t){let{slots:n}=t;const{themeClasses:s}=q(e),{densityClasses:a}=Be(e),{borderClasses:i}=we(e),{elevationClasses:o}=Se(e),{roundedClasses:d}=ke(e);ft({VBtn:{height:"auto",color:x(e,"color"),density:x(e,"density"),flat:!0,variant:x(e,"variant")}}),R(()=>l(e.tag,{class:["v-btn-group",{"v-btn-group--divided":e.divided},s.value,i.value,a.value,o.value,d.value]},n))}}),Ot=S({modelValue:{type:null,default:void 0},multiple:Boolean,mandatory:[Boolean,String],max:Number,selectedClass:String,disabled:Boolean},"group"),zt=S({value:null,disabled:Boolean,selectedClass:String},"group-item");function Mt(e,t){let n=arguments.length>2&&arguments[2]!==void 0?arguments[2]:!0;const s=Ee("useGroupItem");if(!s)throw new Error("[Vuetify] useGroupItem composable must be used inside a component setup function");const a=vt();Ve(Symbol.for(`${t.description}:id`),a);const i=mt(t,null);if(!i){if(!n)return i;throw new Error(`[Vuetify] Could not find useGroup injection with symbol ${t.description}`)}const o=x(e,"value"),d=f(()=>i.disabled.value||e.disabled);i.register({id:a,value:o,disabled:d},s),K(()=>{i.unregister(a)});const r=f(()=>i.isSelected(a)),g=f(()=>r.value&&[i.selectedClass.value,e.selectedClass]);return J(r,h=>{s.emit("group:selected",{value:h})}),{id:a,isSelected:r,toggle:()=>i.select(a,!r.value),select:h=>i.select(a,h),selectedClass:g,value:o,disabled:d,group:i}}function Dt(e,t){let n=!1;const s=gt([]),a=pt(e,"modelValue",[],u=>u==null?[]:Ae(s,bt(u)),u=>{const c=Wt(s,u);return e.multiple?c:c[0]}),i=Ee("useGroup");function o(u,c){const p=u,m=Symbol.for(`${t.description}:id`),b=_t(m,i==null?void 0:i.vnode).indexOf(c);b>-1?s.splice(b,0,p):s.push(p)}function d(u){if(n)return;r();const c=s.findIndex(p=>p.id===u);s.splice(c,1)}function r(){const u=s.find(c=>!c.disabled);u&&e.mandatory==="force"&&!a.value.length&&(a.value=[u.id])}ht(()=>{r()}),K(()=>{n=!0});function g(u,c){const p=s.find(m=>m.id===u);if(!(c&&(p==null?void 0:p.disabled)))if(e.multiple){const m=a.value.slice(),y=m.findIndex(v=>v===u),b=~y;if(c=c!=null?c:!b,b&&e.mandatory&&m.length<=1||!b&&e.max!=null&&m.length+1>e.max)return;y<0&&c?m.push(u):y>=0&&!c&&m.splice(y,1),a.value=m}else{const m=a.value.includes(u);if(e.mandatory&&m)return;a.value=(c!=null?c:!m)?[u]:[]}}function h(u){if(e.multiple&&Ct('This method is not supported when using "multiple" prop'),a.value.length){const c=a.value[0],p=s.findIndex(b=>b.id===c);let m=(p+u)%s.length,y=s[m];for(;y.disabled&&m!==p;)m=(m+u)%s.length,y=s[m];if(y.disabled)return;a.value=[s[m].id]}else{const c=s.find(p=>!p.disabled);c&&(a.value=[c.id])}}const w={register:o,unregister:d,selected:a,select:g,disabled:x(e,"disabled"),prev:()=>h(s.length-1),next:()=>h(1),isSelected:u=>a.value.includes(u),selectedClass:f(()=>e.selectedClass),items:f(()=>s),getItemIndex:u=>Ut(s,u)};return Ve(t,w),w}function Ut(e,t){const n=Ae(e,[t]);return n.length?e.findIndex(s=>s.id===n[0]):-1}function Ae(e,t){const n=[];for(let s=0;s<e.length;s++){const a=e[s];a.value!=null?t.find(i=>yt(i,a.value))!=null&&n.push(a.id):t.includes(s)&&n.push(a.id)}return n}function Wt(e,t){const n=[];for(let s=0;s<e.length;s++){const a=e[s];t.includes(a.id)&&n.push(a.value!=null?a.value:s)}return n}const je=Symbol.for("vuetify:v-btn-toggle");E()({name:"VBtnToggle",props:{...Re(),...Ot()},emits:{"update:modelValue":e=>!0},setup(e,t){let{slots:n}=t;const{isSelected:s,next:a,prev:i,select:o,selected:d}=Dt(e,je);return R(()=>{const[r]=ve.filterProps(e);return l(ve,wt({class:"v-btn-toggle"},r),{default:()=>{var g;return[(g=n.default)==null?void 0:g.call(n,{isSelected:s,next:a,prev:i,select:o,selected:d})]}})}),{next:a,prev:i,select:o}}});function Ht(e){const t=H(),n=H(!1);if(St){const s=new IntersectionObserver(a=>{e==null||e(a,s),n.value=!!a.find(i=>i.isIntersecting)});K(()=>{s.disconnect()}),J(t,(a,i)=>{i&&(s.unobserve(i),n.value=!1),a&&s.observe(a)},{flush:"post"})}return{intersectionRef:t,isIntersecting:n}}const Ft=E()({name:"VProgressCircular",props:{bgColor:String,color:String,indeterminate:[Boolean,String],modelValue:{type:[Number,String],default:0},rotate:{type:[Number,String],default:0},width:{type:[Number,String],default:4},...xe(),...I({tag:"div"}),...X()},setup(e,t){let{slots:n}=t;const s=20,a=2*Math.PI*s,i=H(),{themeClasses:o}=q(e),{sizeClasses:d,sizeStyles:r}=Le(e),{textColorClasses:g,textColorStyles:h}=oe(x(e,"color")),{textColorClasses:w,textColorStyles:u}=oe(x(e,"bgColor")),{intersectionRef:c,isIntersecting:p}=Ht(),{resizeRef:m,contentRect:y}=ot(),b=f(()=>Math.max(0,Math.min(100,parseFloat(e.modelValue)))),v=f(()=>Number(e.width)),_=f(()=>r.value?Number(e.size):y.value?y.value.width:Math.max(v.value,32)),T=f(()=>s/(1-v.value/_.value)*2),L=f(()=>v.value/_.value*T.value),z=f(()=>kt((100-b.value)/100*a));return xt(()=>{c.value=i.value,m.value=i.value}),R(()=>l(e.tag,{ref:i,class:["v-progress-circular",{"v-progress-circular--indeterminate":!!e.indeterminate,"v-progress-circular--visible":p.value,"v-progress-circular--disable-shrink":e.indeterminate==="disable-shrink"},o.value,d.value,g.value],style:[r.value,h.value],role:"progressbar","aria-valuemin":"0","aria-valuemax":"100","aria-valuenow":e.indeterminate?void 0:b.value},{default:()=>[l("svg",{style:{transform:`rotate(calc(-90deg + ${Number(e.rotate)}deg))`},xmlns:"http://www.w3.org/2000/svg",viewBox:`0 0 ${T.value} ${T.value}`},[l("circle",{class:["v-progress-circular__underlay",w.value],style:u.value,fill:"transparent",cx:"50%",cy:"50%",r:s,"stroke-width":L.value,"stroke-dasharray":a,"stroke-dashoffset":0},null),l("circle",{class:"v-progress-circular__overlay",fill:"transparent",cx:"50%",cy:"50%",r:s,"stroke-width":L.value,"stroke-dasharray":a,"stroke-dashoffset":z.value},null)]),n.default&&l("div",{class:"v-progress-circular__content"},[n.default({value:b.value})])]})),{}}});const F=Symbol("rippleStop"),Yt=80;function me(e,t){e.style.transform=t,e.style.webkitTransform=t}function Y(e){return e.constructor.name==="TouchEvent"}function Ge(e){return e.constructor.name==="KeyboardEvent"}const Xt=function(e,t){var w;let n=arguments.length>2&&arguments[2]!==void 0?arguments[2]:{},s=0,a=0;if(!Ge(e)){const u=t.getBoundingClientRect(),c=Y(e)?e.touches[e.touches.length-1]:e;s=c.clientX-u.left,a=c.clientY-u.top}let i=0,o=.3;(w=t._ripple)!=null&&w.circle?(o=.15,i=t.clientWidth/2,i=n.center?i:i+Math.sqrt((s-i)**2+(a-i)**2)/4):i=Math.sqrt(t.clientWidth**2+t.clientHeight**2)/2;const d=`${(t.clientWidth-i*2)/2}px`,r=`${(t.clientHeight-i*2)/2}px`,g=n.center?d:`${s-i}px`,h=n.center?r:`${a-i}px`;return{radius:i,scale:o,x:g,y:h,centerX:d,centerY:r}},j={show(e,t){var c;let n=arguments.length>2&&arguments[2]!==void 0?arguments[2]:{};if(!((c=t==null?void 0:t._ripple)!=null&&c.enabled))return;const s=document.createElement("span"),a=document.createElement("span");s.appendChild(a),s.className="v-ripple__container",n.class&&(s.className+=` ${n.class}`);const{radius:i,scale:o,x:d,y:r,centerX:g,centerY:h}=Xt(e,t,n),w=`${i*2}px`;a.className="v-ripple__animation",a.style.width=w,a.style.height=w,t.appendChild(s);const u=window.getComputedStyle(t);u&&u.position==="static"&&(t.style.position="relative",t.dataset.previousPosition="static"),a.classList.add("v-ripple__animation--enter"),a.classList.add("v-ripple__animation--visible"),me(a,`translate(${d}, ${r}) scale3d(${o},${o},${o})`),a.dataset.activated=String(performance.now()),setTimeout(()=>{a.classList.remove("v-ripple__animation--enter"),a.classList.add("v-ripple__animation--in"),me(a,`translate(${g}, ${h}) scale3d(1,1,1)`)},0)},hide(e){var i;if(!((i=e==null?void 0:e._ripple)!=null&&i.enabled))return;const t=e.getElementsByClassName("v-ripple__animation");if(t.length===0)return;const n=t[t.length-1];if(n.dataset.isHiding)return;n.dataset.isHiding="true";const s=performance.now()-Number(n.dataset.activated),a=Math.max(250-s,0);setTimeout(()=>{n.classList.remove("v-ripple__animation--in"),n.classList.add("v-ripple__animation--out"),setTimeout(()=>{var d;e.getElementsByClassName("v-ripple__animation").length===1&&e.dataset.previousPosition&&(e.style.position=e.dataset.previousPosition,delete e.dataset.previousPosition),((d=n.parentNode)==null?void 0:d.parentNode)===e&&e.removeChild(n.parentNode)},300)},a)}};function Oe(e){return typeof e>"u"||!!e}function B(e){const t={},n=e.currentTarget;if(!(!(n!=null&&n._ripple)||n._ripple.touched||e[F])){if(e[F]=!0,Y(e))n._ripple.touched=!0,n._ripple.isTouch=!0;else if(n._ripple.isTouch)return;if(t.center=n._ripple.centered||Ge(e),n._ripple.class&&(t.class=n._ripple.class),Y(e)){if(n._ripple.showTimerCommit)return;n._ripple.showTimerCommit=()=>{j.show(e,n,t)},n._ripple.showTimer=window.setTimeout(()=>{var s;(s=n==null?void 0:n._ripple)!=null&&s.showTimerCommit&&(n._ripple.showTimerCommit(),n._ripple.showTimerCommit=null)},Yt)}else j.show(e,n,t)}}function ge(e){e[F]=!0}function C(e){const t=e.currentTarget;if(!!(t!=null&&t._ripple)){if(window.clearTimeout(t._ripple.showTimer),e.type==="touchend"&&t._ripple.showTimerCommit){t._ripple.showTimerCommit(),t._ripple.showTimerCommit=null,t._ripple.showTimer=window.setTimeout(()=>{C(e)});return}window.setTimeout(()=>{t._ripple&&(t._ripple.touched=!1)}),j.hide(t)}}function ze(e){const t=e.currentTarget;!(t!=null&&t._ripple)||(t._ripple.showTimerCommit&&(t._ripple.showTimerCommit=null),window.clearTimeout(t._ripple.showTimer))}let N=!1;function Me(e){!N&&(e.keyCode===ue.enter||e.keyCode===ue.space)&&(N=!0,B(e))}function De(e){N=!1,C(e)}function Ue(e){N&&(N=!1,C(e))}function We(e,t,n){var o;const{value:s,modifiers:a}=t,i=Oe(s);if(i||j.hide(e),e._ripple=(o=e._ripple)!=null?o:{},e._ripple.enabled=i,e._ripple.centered=a.center,e._ripple.circle=a.circle,Lt(s)&&s.class&&(e._ripple.class=s.class),i&&!n){if(a.stop){e.addEventListener("touchstart",ge,{passive:!0}),e.addEventListener("mousedown",ge);return}e.addEventListener("touchstart",B,{passive:!0}),e.addEventListener("touchend",C,{passive:!0}),e.addEventListener("touchmove",ze,{passive:!0}),e.addEventListener("touchcancel",C),e.addEventListener("mousedown",B),e.addEventListener("mouseup",C),e.addEventListener("mouseleave",C),e.addEventListener("keydown",Me),e.addEventListener("keyup",De),e.addEventListener("blur",Ue),e.addEventListener("dragstart",C,{passive:!0})}else!i&&n&&He(e)}function He(e){e.removeEventListener("mousedown",B),e.removeEventListener("touchstart",B),e.removeEventListener("touchend",C),e.removeEventListener("touchmove",ze),e.removeEventListener("touchcancel",C),e.removeEventListener("mouseup",C),e.removeEventListener("mouseleave",C),e.removeEventListener("keydown",Me),e.removeEventListener("keyup",De),e.removeEventListener("dragstart",C),e.removeEventListener("blur",Ue)}function qt(e,t){We(e,t,!1)}function Kt(e){delete e._ripple,He(e)}function Jt(e,t){if(t.value===t.oldValue)return;const n=Oe(t.oldValue);We(e,t,n)}const Zt={mounted:qt,unmounted:Kt,updated:Jt},pe={center:"center",top:"bottom",bottom:"top",left:"right",right:"left"},Qt=S({location:String},"location");function en(e){let t=arguments.length>1&&arguments[1]!==void 0?arguments[1]:!1,n=arguments.length>2?arguments[2]:void 0;const{isRtl:s}=Et();return{locationStyles:f(()=>{if(!e.location)return{};const{side:i,align:o}=Nt(e.location.split(" ").length>1?e.location:`${e.location} center`,s.value);function d(g){return n?n(g):0}const r={};return i!=="center"&&(t?r[pe[i]]=`calc(100% - ${d(i)}px)`:r[i]=0),o!=="center"?t?r[pe[o]]=`calc(100% - ${d(o)}px)`:r[o]=0:(i==="center"?r.top=r.left="50%":r[{top:"left",bottom:"left",left:"top",right:"top"}[i]]="50%",r.transform={top:"translateX(-50%)",bottom:"translateX(-50%)",left:"translateY(-50%)",right:"translateY(-50%)",center:"translate(-50%, -50%)"}[i]),r})}}const tn=S({loading:[Boolean,String]},"loader");function nn(e){let t=arguments.length>1&&arguments[1]!==void 0?arguments[1]:G();return{loaderClasses:f(()=>({[`${t}--loading`]:e.loading}))}}const sn=["static","relative","fixed","absolute","sticky"],an=S({position:{type:String,validator:e=>sn.includes(e)}},"position");function on(e){let t=arguments.length>1&&arguments[1]!==void 0?arguments[1]:G();return{positionClasses:f(()=>e.position?`${t}--${e.position}`:void 0)}}function ln(e,t){const n=Vt("RouterLink"),s=f(()=>!!(e.href||e.to)),a=f(()=>(s==null?void 0:s.value)||ce(t,"click")||ce(e,"click"));if(typeof n=="string")return{isLink:s,isClickable:a,href:x(e,"href")};const i=e.to?n.useLink(e):void 0;return{isLink:s,isClickable:a,route:i==null?void 0:i.route,navigate:i==null?void 0:i.navigate,isActive:i&&f(()=>{var o,d;return e.exact?(o=i.isExactActive)==null?void 0:o.value:(d=i.isActive)==null?void 0:d.value}),href:f(()=>e.to?i==null?void 0:i.route.value.href:e.href)}}const rn=S({href:String,replace:Boolean,to:[String,Object],exact:Boolean},"router");function un(e,t){J(()=>{var n;return(n=e.isActive)==null?void 0:n.value},n=>{e.isLink.value&&n&&t&&It(()=>{t(!0)})},{immediate:!0})}const cn=S({active:{type:Boolean,default:void 0},symbol:{type:null,default:je},flat:Boolean,icon:[Boolean,String,Function,Object],prependIcon:de,appendIcon:de,block:Boolean,stacked:Boolean,ripple:{type:Boolean,default:!0},...be(),...Ce(),...Pe(),...lt(),..._e(),...zt(),...tn(),...Qt(),...an(),...rn(),...xe(),...I({tag:"button"}),...X(),...Ne({variant:"elevated"})},"VBtn"),U=E()({name:"VBtn",directives:{Ripple:Zt},props:cn(),emits:{"group:selected":e=>!0},setup(e,t){let{attrs:n,slots:s}=t;const{themeClasses:a}=q(e),{borderClasses:i}=we(e),{colorClasses:o,colorStyles:d,variantClasses:r}=Gt(e),{densityClasses:g}=Be(e),{dimensionStyles:h}=rt(e),{elevationClasses:w}=Se(e),{loaderClasses:u}=nn(e),{locationStyles:c}=en(e),{positionClasses:p}=on(e),{roundedClasses:m}=ke(e),{sizeClasses:y,sizeStyles:b}=Le(e),v=Mt(e,e.symbol,!1),_=ln(e,n),T=f(()=>{var $;return e.active!==void 0?e.active:_.isLink.value?($=_.isActive)==null?void 0:$.value:v==null?void 0:v.isSelected.value}),L=f(()=>(v==null?void 0:v.disabled.value)||e.disabled),z=f(()=>e.variant==="elevated"&&!(e.disabled||e.flat||e.border)),nt=f(()=>{if(e.value!==void 0)return Object(e.value)===e.value?JSON.stringify(e.value,null,0):e.value});return un(_,v==null?void 0:v.select),R(()=>{var ae,ie;const $=_.isLink.value?"a":e.tag,st=!!(e.prependIcon||s.prepend),at=!!(e.appendIcon||s.append),ne=!!(e.icon&&e.icon!==!0),se=(v==null?void 0:v.isSelected.value)&&(!_.isLink.value||((ae=_.isActive)==null?void 0:ae.value))||!v||((ie=_.isActive)==null?void 0:ie.value);return Tt(l($,{type:$==="a"?void 0:"button",class:["v-btn",v==null?void 0:v.selectedClass.value,{"v-btn--active":T.value,"v-btn--block":e.block,"v-btn--disabled":L.value,"v-btn--elevated":z.value,"v-btn--flat":e.flat,"v-btn--icon":!!e.icon,"v-btn--loading":e.loading,"v-btn--stacked":e.stacked},a.value,i.value,se?o.value:void 0,g.value,w.value,u.value,p.value,m.value,y.value,r.value],style:[se?d.value:void 0,h.value,c.value,b.value],disabled:L.value||void 0,href:_.href.value,onClick:A=>{var P;L.value||((P=_.navigate)==null||P.call(_,A),v==null||v.toggle())},value:nt.value},{default:()=>{var A,P;return[jt(!0,"v-btn"),!e.icon&&st&&l("span",{key:"prepend",class:"v-btn__prepend"},[s.prepend?l(M,{key:"prepend-defaults",disabled:!e.prependIcon,defaults:{VIcon:{icon:e.prependIcon}}},s.prepend):l(V,{key:"prepend-icon",icon:e.prependIcon},null)]),l("span",{class:"v-btn__content","data-no-activator":""},[!s.default&&ne?l(V,{key:"content-icon",icon:e.icon},null):l(M,{key:"content-defaults",disabled:!ne,defaults:{VIcon:{icon:e.icon}}},s.default)]),!e.icon&&at&&l("span",{key:"append",class:"v-btn__append"},[s.append?l(M,{key:"append-defaults",disabled:!e.appendIcon,defaults:{VIcon:{icon:e.appendIcon}}},s.append):l(V,{key:"append-icon",icon:e.appendIcon},null)]),!!e.loading&&l("span",{key:"loader",class:"v-btn__loader"},[(P=(A=s.loader)==null?void 0:A.call(s))!=null?P:l(Ft,{color:typeof e.loading=="boolean"?void 0:e.loading,indeterminate:!0,size:"23",width:"2"},null)])]}}),[[$t("ripple"),!L.value&&e.ripple,null]])}),{}}}),dn="/assets/logo.3f834fa8.svg";const fn=E()({name:"VContainer",props:{fluid:{type:Boolean,default:!1},...I()},setup(e,t){let{slots:n}=t;return R(()=>l(e.tag,{class:["v-container",{"v-container--fluid":e.fluid}]},n)),{}}}),Fe=(()=>O.reduce((e,t)=>(e[t]={type:[Boolean,String,Number],default:!1},e),{}))(),Ye=(()=>O.reduce((e,t)=>{const n="offset"+Z(t);return e[n]={type:[String,Number],default:null},e},{}))(),Xe=(()=>O.reduce((e,t)=>{const n="order"+Z(t);return e[n]={type:[String,Number],default:null},e},{}))(),he={col:Object.keys(Fe),offset:Object.keys(Ye),order:Object.keys(Xe)};function vn(e,t,n){let s=e;if(!(n==null||n===!1)){if(t){const a=t.replace(e,"");s+=`-${a}`}return e==="col"&&(s="v-"+s),e==="col"&&(n===""||n===!0)||(s+=`-${n}`),s.toLowerCase()}}const mn=["auto","start","end","center","baseline","stretch"],W=E()({name:"VCol",props:{cols:{type:[Boolean,String,Number],default:!1},...Fe,offset:{type:[String,Number],default:null},...Ye,order:{type:[String,Number],default:null},...Xe,alignSelf:{type:String,default:null,validator:e=>mn.includes(e)},...I()},setup(e,t){let{slots:n}=t;const s=f(()=>{const a=[];let i;for(i in he)he[i].forEach(d=>{const r=e[d],g=vn(i,d,r);g&&a.push(g)});const o=a.some(d=>d.startsWith("v-col-"));return a.push({"v-col":!o||!e.cols,[`v-col-${e.cols}`]:e.cols,[`offset-${e.offset}`]:e.offset,[`order-${e.order}`]:e.order,[`align-self-${e.alignSelf}`]:e.alignSelf}),a});return()=>{var a;return Ie(e.tag,{class:s.value},(a=n.default)==null?void 0:a.call(n))}}}),ee=["start","end","center"],qe=["space-between","space-around","space-evenly"];function te(e,t){return O.reduce((n,s)=>{const a=e+Z(s);return n[a]=t(),n},{})}const gn=[...ee,"baseline","stretch"],Ke=e=>gn.includes(e),Je=te("align",()=>({type:String,default:null,validator:Ke})),pn=[...ee,...qe],Ze=e=>pn.includes(e),Qe=te("justify",()=>({type:String,default:null,validator:Ze})),hn=[...ee,...qe,"stretch"],et=e=>hn.includes(e),tt=te("alignContent",()=>({type:String,default:null,validator:et})),ye={align:Object.keys(Je),justify:Object.keys(Qe),alignContent:Object.keys(tt)},yn={align:"align",justify:"justify",alignContent:"align-content"};function bn(e,t,n){let s=yn[e];if(n!=null){if(t){const a=t.replace(e,"");s+=`-${a}`}return s+=`-${n}`,s.toLowerCase()}}const _n=E()({name:"VRow",props:{dense:Boolean,noGutters:Boolean,align:{type:String,default:null,validator:Ke},...Je,justify:{type:String,default:null,validator:Ze},...Qe,alignContent:{type:String,default:null,validator:et},...tt,...I()},setup(e,t){let{slots:n}=t;const s=f(()=>{const a=[];let i;for(i in ye)ye[i].forEach(o=>{const d=e[o],r=bn(i,o,d);r&&a.push(r)});return a.push({"v-row--no-gutters":e.noGutters,"v-row--dense":e.dense,[`align-${e.align}`]:e.align,[`justify-${e.justify}`]:e.justify,[`align-content-${e.alignContent}`]:e.alignContent}),a});return()=>{var a;return Ie(e.tag,{class:["v-row",s.value]},(a=n.default)==null?void 0:a.call(n))}}}),Cn=Q("div",{class:"text-body-2 font-weight-light mb-n1"},"Welcome to",-1),wn=Q("h1",{class:"text-h2 font-weight-bold"},"Vuetify",-1),Sn=Q("div",{class:"py-14"},null,-1),kn={__name:"HelloWorld",setup(e){return(t,n)=>(Te(),$e(fn,{class:"fill-height"},{default:k(()=>[l(ut,{class:"d-flex align-center text-center fill-height"},{default:k(()=>[l(ct,{contain:"",height:"300",src:dn}),Cn,wn,Sn,l(_n,{class:"d-flex align-center justify-center"},{default:k(()=>[l(W,{cols:"auto"},{default:k(()=>[l(U,{href:"https://next.vuetifyjs.com/components/all/","min-width":"164",rel:"noopener noreferrer",target:"_blank",variant:"text"},{default:k(()=>[l(V,{icon:"mdi-view-dashboard",size:"large",start:""}),D(" Components ")]),_:1})]),_:1}),l(W,{cols:"auto"},{default:k(()=>[l(U,{color:"primary",href:"https://next.vuetifyjs.com/introduction/why-vuetify/#feature-guides","min-width":"228",rel:"noopener noreferrer",size:"x-large",target:"_blank",variant:"flat"},{default:k(()=>[l(V,{icon:"mdi-speedometer",size:"large",start:""}),D(" Get Started ")]),_:1})]),_:1}),l(W,{cols:"auto"},{default:k(()=>[l(U,{href:"https://community.vuetifyjs.com/","min-width":"164",rel:"noopener noreferrer",target:"_blank",variant:"text"},{default:k(()=>[l(V,{icon:"mdi-account-group",size:"large",start:""}),D(" Community ")]),_:1})]),_:1})]),_:1})]),_:1})]),_:1}))}},En={__name:"Home",setup(e){return(t,n)=>(Te(),$e(kn))}};export{En as default};