/// <reference types="react" />
import { AbstractPureComponent } from "../../common";
import { type HTMLDivProps, type Props } from "../../common/props";
export interface NavbarDividerProps extends Props, HTMLDivProps {
}
export declare class NavbarDivider extends AbstractPureComponent<NavbarDividerProps> {
    static displayName: string;
    render(): JSX.Element;
}
